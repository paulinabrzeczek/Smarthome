using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.DeviceTypes
{
    public interface IDeviceTypeRepository
    {
        Task<IList<DeviceTypeDb>> GetDeviceTypeAsync();
    }
}
