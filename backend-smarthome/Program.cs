using backend_smarthome.Controllers;
using backend_smarthome.DAL;
using backend_smarthome.Helpers;
using backend_smarthome.Repository.Addresses;
using backend_smarthome.Repository.Apartments;
using backend_smarthome.Repository.CountryCode;
using backend_smarthome.Repository.Devices;
using backend_smarthome.Repository.DeviceTypes;
using backend_smarthome.Repository.Guests;
using backend_smarthome.Repository.Heads;
using backend_smarthome.Repository.Rooms;
using backend_smarthome.Repository.RoomTypes;
using backend_smarthome.Repository.Users;
using backend_smarthome.Service.Apartments;
using backend_smarthome.Service.CountryCode;
using backend_smarthome.Service.Devices;
using backend_smarthome.Service.DeviceTypes;
using backend_smarthome.Service.Guests;
using backend_smarthome.Service.Head;
using backend_smarthome.Service.Rooms;
using backend_smarthome.Service.RoomTypes;
using backend_smarthome.Service.SSE;
using backend_smarthome.Service.Users;
using EHome.Keycloak.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var isRunningInDocker = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"));

if (isRunningInDocker)
{
    var server = Environment.GetEnvironmentVariable("DB_HOST");
    var user = Environment.GetEnvironmentVariable("DB_USER");
    var database = Environment.GetEnvironmentVariable("DB_NAME");
    var password = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

    var connectionString = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";

    builder.Services.AddDbContext<SmarthomeDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    builder.Services.AddDbContext<SmarthomeDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//KeyCloak
builder.Services.AddHttpClient();
builder.Services.AddCors();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var keycloakOptions = builder.Configuration.GetSection("Keycloak").Get<KeycloakOptions>();

        options.MetadataAddress = keycloakOptions.Metadata;
        options.Authority = keycloakOptions.Authority;
        options.Audience = keycloakOptions.Audience;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateLifetime = false,
            ValidateAudience = false,
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(_ =>
{
    _.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter Bearer token here",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    });
    _.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
    _.EnableAnnotations();
});

//Repos
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IHeadRepository, HeadRepository>();
builder.Services.AddScoped<ICountryCodeRepository, CountryCodeRepository>();

//Services
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IDeviceTypeService, DeviceTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IKeycloakClient, KeycloakClient>();
builder.Services.AddScoped<IEventStreamService, EventStreamService>();
builder.Services.AddScoped<IHeadService, HeadService>();
builder.Services.AddScoped<ICountryCodeService, CountryCodeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(_ =>
    {
        _.SwaggerEndpoint("/swagger/v1/swagger.json", "EHome API v1");
        _.DocExpansion(DocExpansion.List);
        _.EnableDeepLinking();

        // Enable OAuth2 authorization support in Swagger UI
        _.OAuthClientId("EHome");
        _.OAuthAppName("Swagger");
    });
}

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<SmarthomeDbContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseStaticFiles();

app.MapControllers();

app.Run();
