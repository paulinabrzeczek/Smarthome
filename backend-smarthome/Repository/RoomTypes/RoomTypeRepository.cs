using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.RoomTypes
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly SmarthomeDbContext _dbContext;

        public RoomTypeRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<RoomTypeDb>> GetRoomTypeAsync()
        {
            return await _dbContext.RoomTypes.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
