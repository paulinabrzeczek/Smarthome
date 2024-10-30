using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.Guests
{
    public class GuestRepository : IGuestRepository
    {
        private readonly SmarthomeDbContext _dbContext;

        public GuestRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RemoveAsync(Guid guestId)
        {
            return await _dbContext.Guests.Where(x => x.Id == guestId).ExecuteDeleteAsync() > 0;
        }

        public async Task<IList<GuestDb>> GetGuestsByApartmentIdAsync(int apartmentId)
        {
            return await _dbContext.Guests.Where(x => x.ApartmentId == apartmentId)
                .Include(x => x.Apartment)
                    .ThenInclude(x => x.Rooms)
                        .ThenInclude(x => x.Devices)
                .ToListAsync();
        }

        public async Task AddAsync(GuestDb guestDb)
        {
            await _dbContext.Guests.AddAsync(guestDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GuestDb> GetByEmailAsync(string email)
        {
            return await _dbContext.Guests.Where(x => x.Email == email).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(GuestDb guestDb)
        {
            _dbContext.Update(guestDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ApartmentDb?> GetApartmentByGuestEmailAsync(string email)
        {
            var guest = await _dbContext.Guests
                                  .Include(g => g.Apartment)
                                    .ThenInclude(a => a.Address)
                                        .ThenInclude(x => x.Country)
                                  .Include(g => g.Apartment)
                                    .ThenInclude(a => a.Rooms)
                                      .ThenInclude(r => r.Devices)
                                   .Include(g => g.Apartment)
                                    .ThenInclude(a => a.Rooms)
                                      .ThenInclude(r => r.RoomType)
                                  .Include(g => g.Apartment)
                                    .ThenInclude(a => a.User)
                                  .FirstOrDefaultAsync(g => g.Email == email);

            return guest?.Apartment;
        }
    }
}
