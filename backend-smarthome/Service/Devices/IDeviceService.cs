using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;

namespace backend_smarthome.Service.Devices
{
    public interface IDeviceService
    {
        Task<IList<DeviceDto>> GetDevicesAssignedToRoom(int roomId);
        Task<bool> RemoveAsync(int deviceId);
        Task AddAsync(AddDeviceDto deviceDb, int roomId);
        Task<bool> IsSerialNumberAssignedToUserAsync(string serialNumber, Guid userId);
        Task<DeviceDto?> FindByIdAsync(int deviceId);
        Task AddDevicesAsync(DevicesDto deviceDto, Guid userId);
    }
}
