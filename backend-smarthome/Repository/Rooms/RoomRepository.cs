using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SmarthomeDbContext _dbContext;
        public RoomRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(RoomDb roomDb)
        {
            await _dbContext.Rooms.AddAsync(roomDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(int roomId)
        {
            return await _dbContext.Apartments.Where(x => x.Id == roomId).AnyAsync();
        }

        public async Task<RoomDb?> FindByIdAsync(int roomId)
        {
            return await _dbContext.Rooms.Where(x => x.Id == roomId)
                .Include(x => x.Apartment)
                .Include(x => x.Devices)
                    .ThenInclude(x => x.Devices)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<RoomDb>> GetRoomsAsync()
        {
            return await _dbContext.Rooms.OrderBy(x => x.Id)
                 .Include(x => x.Apartment)
                 .Include(x => x.Devices)
                    .ThenInclude(x => x.Devices)
                 .ToListAsync();
        }

        public async Task<bool> RemoveAsync(int roomId)
        {
            return await _dbContext.Rooms.Where(x => x.Id == roomId).ExecuteDeleteAsync() > 0;
        }

        public async Task UpdateAsync(RoomDb roomDb)
        {
            _dbContext.Update(roomDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CountDevicesInApartmentAsync(int apartmentId)
        {
            return await _dbContext.Rooms
                                 .Where(r => r.ApartmentId == apartmentId)
                                 .SelectMany(r => r.Devices)
                                 .CountAsync();
        }
    }
}
