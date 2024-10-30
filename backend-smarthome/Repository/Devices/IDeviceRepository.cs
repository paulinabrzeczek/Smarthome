using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.Devices
{
    public interface IDeviceRepository
    {
        Task<IList<DeviceDb>> GetDevicesAssignedToRoom(int roomId);
        Task<bool> RemoveAsync(int deviceId);
        Task AddAsync(DeviceDb deviceDb);
        Task<bool> IsSerialNumberAssignedToUserAsync(string serialNumber, Guid userId);
        Task<DeviceDb?> FindByIdAsync(int deviceId);
        Task<bool> CheckIfExistsAsync(int deviceId);
        Task AddDevicesAsync(DevicesDb devicesDb);
        Task<bool> CheckIfSerialNumberExistsAsync(string serialNumber);
    }
}
