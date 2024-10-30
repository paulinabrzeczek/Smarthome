using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.CountryCode
{
    public class CountryCodeRepository : ICountryCodeRepository
    {
        private readonly SmarthomeDbContext _dbContext;
        public CountryCodeRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<CountryDb>> GetAllCountryCodesAsync()
        {
            return await _dbContext.Countrys.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<CountryDb?> GetByIdAsync(int countryId)
        {
            return await _dbContext.Countrys.FindAsync(countryId);
        }
    }
}
