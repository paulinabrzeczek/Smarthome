using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EHome.Keycloak.Client.Models.User
{
    public class User
    {
        [JsonProperty("id")] 
        public string Id { get; set; }
        [JsonProperty("createdTimestamp")]
        public long CreatedTimestamp { get; set; }
        [JsonProperty("username")] 
        public string UserName { get; set; }
        [JsonProperty("enabled")] 
        public bool? Enabled { get; set; }
        [JsonProperty("totp")] 
        public bool? Totp { get; set; }
        [JsonProperty("emailVerified")] 
        public bool? EmailVerified { get; set; }
        [JsonProperty("firstName")] 
        public string FirstName { get; set; }
        [JsonProperty("lastName")] 
        public string LastName { get; set; }
        [JsonProperty("email")] 
        public string Email { get; set; }
    }
}
