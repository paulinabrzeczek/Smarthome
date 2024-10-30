using backend_smarthome.DAL.Configuration;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.DAL
{
    public class SmarthomeDbContext : DbContext
    {
        public DbSet<ApartmentDb> Apartments { get; set; }
        public DbSet<DeviceDb> Devices { get; set; }
        public DbSet<RoomDb> Rooms { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<AddressDb> Addresss { get; set; }
        public DbSet<RoomTypeDb> RoomTypes { get; set; }
        public DbSet<DeviceTypeDb> DeviceTypes { get; set; }
        public DbSet<GuestDb> Guests { get; set; }
        public DbSet<DevicesDb> Devicess { get; set; }
        public DbSet<HeadDb> Heads { get; set; }
        public DbSet<CountryDb> Countrys { get; set; }

        public SmarthomeDbContext(DbContextOptions<SmarthomeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomTypeDb>().HasData(
                 new RoomTypeDb { Id = 1, Code = "BATHROOM", Value = "Bathroom" },
                 new RoomTypeDb { Id = 2, Code = "BEDROOM", Value = "Bedroom" },
                 new RoomTypeDb { Id = 3, Code = "KITCHEN", Value = "Kitchen" },
                 new RoomTypeDb { Id = 4, Code = "LIVING_ROOM", Value = "Living room" },
                 new RoomTypeDb { Id = 5, Code = "HALL", Value = "Hall" },
                 new RoomTypeDb { Id = 6, Code = "DINING_ROOM", Value = "Dining room" }
             );
            modelBuilder.Entity<DeviceTypeDb>().HasData(
                new DeviceTypeDb { Id = 1, Code = "BB", Value = "Bulb" },
                new DeviceTypeDb { Id = 2, Code = "TV", Value = "Television" },
                new DeviceTypeDb { Id = 3, Code = "AC", Value = "Air Conditioning" },
                new DeviceTypeDb { Id = 4, Code = "HS", Value = "Humidity Sensor" },
                new DeviceTypeDb { Id = 5, Code = "TS", Value = "Temperature Sensor" },
                new DeviceTypeDb { Id = 6, Code = "OU", Value = "Outlet" }
            );
            modelBuilder.Entity<CountryDb>().HasData(
                new CountryDb { Id = 1, Code = "AT", Value = "Austria" },
                new CountryDb { Id = 2, Code = "BE", Value = "Belgium" },
                new CountryDb { Id = 3, Code = "BG", Value = "Bulgaria" },
                new CountryDb { Id = 4, Code = "HR", Value = "Croatia" },
                new CountryDb { Id = 5, Code = "CY", Value = "Cyprus" },
                new CountryDb { Id = 6, Code = "CZ", Value = "Czech Republic" },
                new CountryDb { Id = 7, Code = "DK", Value = "Denmark" },
                new CountryDb { Id = 8, Code = "EE", Value = "Estonia" },
                new CountryDb { Id = 9, Code = "FI", Value = "Finland" },
                new CountryDb { Id = 10, Code = "FR", Value = "France" },
                new CountryDb { Id = 11, Code = "DE", Value = "Germany" },
                new CountryDb { Id = 12, Code = "GR", Value = "Greece" },
                new CountryDb { Id = 13, Code = "HU", Value = "Hungary" },
                new CountryDb { Id = 14, Code = "IE", Value = "Ireland" },
                new CountryDb { Id = 15, Code = "IT", Value = "Italy" },
                new CountryDb { Id = 16, Code = "LV", Value = "Latvia" },
                new CountryDb { Id = 17, Code = "LT", Value = "Lithuania" },
                new CountryDb { Id = 18, Code = "LU", Value = "Luxembourg" },
                new CountryDb { Id = 19, Code = "MT", Value = "Malta" },
                new CountryDb { Id = 20, Code = "NL", Value = "Netherlands" },
                new CountryDb { Id = 21, Code = "PL", Value = "Poland" },
                new CountryDb { Id = 22, Code = "PT", Value = "Portugal" },
                new CountryDb { Id = 23, Code = "RO", Value = "Romania" },
                new CountryDb { Id = 24, Code = "SK", Value = "Slovakia" },
                new CountryDb { Id = 25, Code = "SI", Value = "Slovenia" },
                new CountryDb { Id = 26, Code = "ES", Value = "Spain" },
                new CountryDb { Id = 27, Code = "SE", Value = "Sweden" }
            );

            modelBuilder.Entity<UserDb>()
                .Property(x => x.Username).IsRequired(false);

            modelBuilder.Entity<UserDb>()
                .Property(x => x.Email).IsRequired(false);

            modelBuilder.Entity<DeviceDb>()
            .HasIndex(d => d.DeviceTypeId)
            .IsUnique(false);

            modelBuilder.ApplyConfiguration(new ApartmentDbConfiguration());
            modelBuilder.ApplyConfiguration(new DevicesDbConfiguration());
            modelBuilder.ApplyConfiguration(new GuestDbConfiguration());
        }
    }
}
