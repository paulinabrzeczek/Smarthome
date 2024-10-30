using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SmarthomeDbContext _dbContext;
        public UserRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(UserDb userDb)
        {
            await _dbContext.Users.AddAsync(userDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(Guid userId)
        {
            return await _dbContext.Users.Where(x => x.Id == userId).AnyAsync();
        }
    }
}
