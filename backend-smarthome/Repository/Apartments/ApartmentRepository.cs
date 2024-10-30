using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.Apartments
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly SmarthomeDbContext _dbContext;
        public ApartmentRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ApartmentDb apartmentDb)
        {
            await _dbContext.Apartments.AddAsync(apartmentDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ApartmentDb?> FindByIdAsync(int apartmentId)
        {
            return await _dbContext.Apartments.Where(x => x.Id == apartmentId)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Country)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.RoomType)
                .Include(x => x.User)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<ApartmentDb>> GetApartments()
        {
            return await _dbContext.Apartments.OrderBy(x => x.Id)
                .Include(x => x.Address)
                .Include(x => x.Rooms)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task UpdateAsync(ApartmentDb apartmentDb)
        {
            _dbContext.Update(apartmentDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(int apartmentId)
        {
            return await _dbContext.Apartments.Where(x => x.Id == apartmentId).AnyAsync();
        }
        public async Task<bool> RemoveAsync(int apartmentId)
        {
            return await _dbContext.Apartments.Where(x => x.Id == apartmentId).ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> CheckIfNameExistsAsync(string name)
        {
            return await _dbContext.Apartments.Where(x => x.Name == name).AnyAsync();
        }
        public async Task<IList<ApartmentDb>> GetApartmentsByUserIdAsync(Guid userId)
        {
            return await _dbContext.Apartments.Where(x => x.UserId == userId)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Country)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.RoomType)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Devices)
                 .Include(x => x.User)
                    .ThenInclude(x => x.Devices)
                .ToListAsync();
        }
    }
}
