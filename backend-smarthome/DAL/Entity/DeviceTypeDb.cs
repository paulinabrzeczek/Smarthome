namespace backend_smarthome.DAL.Entity
{
    public class DeviceTypeDb
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public DeviceDb Device { get; set; }
    }
}
