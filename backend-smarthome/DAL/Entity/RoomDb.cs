using System.ComponentModel.DataAnnotations.Schema;

namespace backend_smarthome.DAL.Entity
{
    public class RoomDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApartmentId { get; set; }
        public ApartmentDb? Apartment { get; set; }
        public ICollection<DeviceDb>? Devices { get; set; }
        public int RoomTypeId { get; set; }
        public RoomTypeDb RoomType { get; set; }
    }
}
