using backend_smarthome.DTO;

namespace backend_smarthome.Service.Users
{
    public interface IUserService
    {
        Task AddAsync(UserDto userDto, Guid userId);
    }
}
