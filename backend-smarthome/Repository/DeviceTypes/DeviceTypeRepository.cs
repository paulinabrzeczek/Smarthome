using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.DeviceTypes
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly SmarthomeDbContext _dbContext;

        public DeviceTypeRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<DeviceTypeDb>> GetDeviceTypeAsync()
        {
            return await _dbContext.DeviceTypes.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
