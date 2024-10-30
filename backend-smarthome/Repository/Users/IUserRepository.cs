using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.Users
{
    public interface IUserRepository
    {
        Task AddAsync(UserDb userDb);
        Task<bool> CheckIfExistsAsync(Guid userId);
    }
}
