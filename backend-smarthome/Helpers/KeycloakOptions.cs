namespace backend_smarthome.Helpers
{
    public class KeycloakOptions
    {
        public string ServerRealm { get; set; }
        public string Metadata { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenExchange { get; set; }
        public string Audience { get; set; }
        public string BaseUri { get; set; }
        public string Authority { get; set; }
    }
}
