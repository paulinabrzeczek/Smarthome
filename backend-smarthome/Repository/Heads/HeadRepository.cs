using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.Heads
{
    public class HeadRepository : IHeadRepository
    {
        private readonly SmarthomeDbContext _dbContext;
        public HeadRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(HeadDb headDb)
        {
            await _dbContext.Heads.AddAsync(headDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(int headId)
        {
            return await _dbContext.Heads.Where(x => x.Id == headId).AnyAsync();
        }
		public async Task<IList<HeadDb>> GetHeadsByRoomIdAsync(int roomId)
		{
			return await _dbContext.Heads.Where(x => x.RoomId == roomId)
				.Include(x => x.Room)
				.ToListAsync();
		}

	}
}
