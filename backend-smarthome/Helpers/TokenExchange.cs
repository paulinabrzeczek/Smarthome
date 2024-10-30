using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Program;

namespace backend_smarthome.Helpers
{
    public class TokenExchange
    {
        static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration;
        public TokenExchange(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetRefreshTokenAsync(string refreshToken)
        {

            try
            {
                string url = _configuration["Keycloak:TokenExchange"];
                //Important the grant type fro refresh token, must be set to this!
                string grant_type = "refresh_token";
                string client_id = _configuration["Keycloak:ClientId"];
                string client_secret = _configuration["Keycloak:ClientSecret"];
                string token = refreshToken;

                var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                    {"refresh_token", token }
                };

                HttpResponseMessage tokenResponse = await client.PostAsync(url, new FormUrlEncodedContent(form));
                var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                return tok.AccessToken;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetTokenExchangeAsync(string accessToken)
        {
            try
            {
                string url = _configuration["Keycloak:TokenExchange"];
                //Important, the grant types for token exchange, must be set to this!
                string grant_type = "urn:ietf:params:oauth:grant-type:token-exchange";
                string client_id = _configuration["Keycloak:ClientId"];
                string client_secret = _configuration["Keycloak:ClientSecret"];
                string audience = _configuration["Keycloak:Audience"];
                string token = accessToken;

                var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                    {"audience", audience},
                    {"subject_token", token }
                };

                HttpResponseMessage tokenResponse = await client.PostAsync(url, new FormUrlEncodedContent(form));
                var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                return tok.AccessToken;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}