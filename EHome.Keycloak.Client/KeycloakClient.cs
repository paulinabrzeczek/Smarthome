using EHome.Keycloak.Client.Models;
using EHome.Keycloak.Client.Models.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHome.Keycloak.Client
{
    public class KeycloakClient : IKeycloakClient
    {
        private readonly HttpClient _client;

        private readonly IConfiguration _configuration;
        private readonly ILogger<KeycloakClient> _logger;
        private readonly string serverRealm;
        private readonly string baseUri;
        private readonly string client_id;
        private readonly string client_secret;

        public KeycloakClient(IConfiguration configuration, ILogger<KeycloakClient> logger, HttpClient client)
        {
            _configuration = configuration;
            _logger = logger;
            _client = client;
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            serverRealm = configuration["Keycloak:ServerRealm"];
            baseUri = configuration["Keycloak:BaseUri"];
            client_id = configuration["Keycloak:ClientId"];
            client_secret = configuration["Keycloak:ClientSecret"];
        }

        public async Task<string> GetAccessToken()
        {
            var grant_type = "client_credentials";
            var form = new Dictionary<string, string>
            {
                { "grant_type", grant_type }, { "client_id", client_id }, { "client_secret", client_secret }
            };
            _client.BaseAddress = new Uri(baseUri);

            var tokenResponse = await _client.PostAsync(serverRealm + "/protocol/openid-connect/token",
                new FormUrlEncodedContent(form));

            tokenResponse.EnsureSuccessStatusCode();

            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();

            var tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            return tok.AccessToken;
        }

        public async Task<User> GetUserAsync(string accessToken, string userId)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"bearer {accessToken}");
            var response = await _client.GetAsync(baseUri + $@"/users/{userId}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<User>(content);

            return result;
        }

        public async Task<IList<User>> GetUsersAsync(string accessToken)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"bearer {accessToken}");
            var response = await _client.GetAsync(baseUri + "/users");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IList<User>>(content);

            return result;
        }
    }
}
