using backend_smarthome.DAL.Entity;

namespace backend_smarthome.DTO
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public int AddressId { get;set; }
        public ICollection<RoomDto>? Rooms { get; set; }
        public UserDto? User { get; set; }
        public Guid UserId { get; set; }
    }
}
