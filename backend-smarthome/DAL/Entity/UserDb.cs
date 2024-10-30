using backend_smarthome.DAL.Configuration;

namespace backend_smarthome.DAL.Entity
{
    public class UserDb
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<ApartmentDb>? Apartments { get; set; }
        public ICollection<DevicesDb> Devices { get; set; }
        
    }
}
