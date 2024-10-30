using backend_smarthome.DAL.Entity;

namespace backend_smarthome.DTO
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool Active { get; set; }
        public string SerialNumber { get; set; }
        public string Symbol { get; set; }
        public int DeviceTypeId { get; set; }
        public DictionaryDto DeviceType { get; set; }
    }
}
