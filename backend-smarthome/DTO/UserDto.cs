using backend_smarthome.DAL.Entity;

namespace backend_smarthome.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
