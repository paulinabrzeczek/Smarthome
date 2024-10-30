using backend_smarthome.DTO;

namespace backend_smarthome.Service.DeviceTypes
{
    public interface IDeviceTypeService
    {
        Task<IList<DictionaryDto>> GetDeviceTypeAsync();
    }
}
