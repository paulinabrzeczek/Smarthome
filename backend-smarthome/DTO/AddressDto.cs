namespace backend_smarthome.DTO
{
    public class AddressDto
    {
        public int CountryId { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public DictionaryDto Country { get; set; }
    }
}
