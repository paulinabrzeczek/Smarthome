namespace backend_smarthome.DAL.Entity
{
    public class CountryDb
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public ICollection<AddressDb> Address { get; set; }
    }
}
