using backend_smarthome.DAL.Entity;

namespace backend_smarthome.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DictionaryDto RoomType { get; set; }
        public int ApartmentId { get; set; }
        public ICollection<DeviceDto>? Devices { get; set; }
    }
}
