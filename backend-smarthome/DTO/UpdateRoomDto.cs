using backend_smarthome.DAL.Entity;

namespace backend_smarthome.DTO
{
    public class UpdateRoomDto
    {
        public string Name { get; set; }
        public int RoomTypeId { get; set; }
    }
}
