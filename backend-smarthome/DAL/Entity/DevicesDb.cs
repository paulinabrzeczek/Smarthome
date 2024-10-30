namespace backend_smarthome.DAL.Entity
{
    public class DevicesDb
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public bool IsActive { get; set; }


        public UserDb? User { get; set; }
        public Guid? UserId { get; set; }
        public int? DeviceId { get; set; }
        public DeviceDb? Device { get; set; }
    }
}
