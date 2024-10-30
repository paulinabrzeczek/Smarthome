using backend_smarthome.DAL;
using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Repository.Devices
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly SmarthomeDbContext _dbContext;

        public DeviceRepository(SmarthomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(DeviceDb deviceDb)
        {
            await _dbContext.Devices.AddAsync(deviceDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddDevicesAsync(DevicesDb devicesDb)
        {
            await _dbContext.Devicess.AddAsync(devicesDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<DeviceDb>> GetDevicesAssignedToRoom(int roomId)
        {
            return await _dbContext.Devices.Where(x => x.RoomId == roomId)
                .Include(x => x.Room)
                    .ThenInclude(x => x.RoomType)
                .Include(x => x.DeviceType)
                .ToListAsync();
        }

        public async Task<bool> RemoveAsync(int deviceId)
        {
            return await _dbContext.Devices.Where(x => x.Id == deviceId).ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> IsSerialNumberAssignedToUserAsync(string serialNumber, Guid userId)
        {
            return await _dbContext.Devicess.AnyAsync(d => d.SerialNumber == serialNumber && d.UserId == userId);
        }

        public async Task<DeviceDb?> FindByIdAsync(int deviceId)
        {
            return await _dbContext.Devices.Where(x => x.Id == deviceId)
                .Include(x => x.Room)
                .Include(x => x.DeviceType)
                .Include(x => x.Devices)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> CheckIfExistsAsync(int deviceId)
        {
            return await _dbContext.Devices.Where(x => x.Id == deviceId).AnyAsync();
        }

        public async Task<bool> CheckIfSerialNumberExistsAsync(string serialNumber)
        {
            return await _dbContext.Devicess.Where(x => x.SerialNumber == serialNumber).AnyAsync();
        }
    }
}
