using backend_smarthome.DAL.Entity;

namespace backend_smarthome.DAL.Configuration
{
    public abstract class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomDb? Room { get; set; }
        public int RoomId { get; set; }
        public bool Active { get; set; }
        public string Symbol { get; set; }
        public double Value { get; set; }

        public int DeviceTypeId { get; set; }
        public DeviceTypeDb DeviceType { get; set; }
        public int? DevicesId { get; set; }
        public DevicesDb? Devices { get; set; }
    }
}
