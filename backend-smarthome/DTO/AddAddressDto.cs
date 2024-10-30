namespace backend_smarthome.DTO
{
    public class AddAddressDto
    {
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public DictionaryDto Country { get; set; }
    }
}
