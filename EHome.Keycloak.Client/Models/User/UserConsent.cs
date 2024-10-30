using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHome.Keycloak.Client.Models.User
{
    public class UserConsent
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("grantedClientScopes")]
        public IEnumerable<string> GrantedClientScopes { get; set; }

        [JsonProperty("createdDate")]
        public long? CreatedDate { get; set; }

        [JsonProperty("lastUpdatedDate")]
        public long? LastUpdatedDate { get; set; }
    }
}