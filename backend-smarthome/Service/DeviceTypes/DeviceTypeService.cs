using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Repository.DeviceTypes;
using backend_smarthome.Repository.RoomTypes;

namespace backend_smarthome.Service.DeviceTypes
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IDeviceTypeRepository _devicetypeRepository;
        public DeviceTypeService(IDeviceTypeRepository devicetypeRepository)
        {
            _devicetypeRepository = devicetypeRepository;
        }
        public async Task<IList<DictionaryDto>> GetDeviceTypeAsync()
        {
            return (await _devicetypeRepository.GetDeviceTypeAsync()).Select(MapToDto).ToList();
        }

        private static DictionaryDto MapToDto(DeviceTypeDb deviceTypeDb) => Map<DictionaryDto>(deviceTypeDb);

        private static T Map<T>(DeviceTypeDb deviceTypeDb) where T : DictionaryDto, new()
            => new()
            {
                Id = deviceTypeDb.Id,
                Code = deviceTypeDb.Code,
                Value = deviceTypeDb.Value
            };
    }
}
