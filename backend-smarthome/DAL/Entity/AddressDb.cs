namespace backend_smarthome.DAL.Entity
{
    public class AddressDb
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string CountryCode { get; set; }

        public int ApartmentId { get; set; }
        public ApartmentDb Apartment { get; set; }
        public int CountryId { get; set; }
        public CountryDb Country { get; set; }
    }
}
