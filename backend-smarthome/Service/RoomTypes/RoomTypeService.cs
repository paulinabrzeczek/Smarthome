using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Repository.RoomTypes;

namespace backend_smarthome.Service.RoomTypes
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<IList<DictionaryDto>> GetRoomTypeAsync()
        {
            return (await _roomTypeRepository.GetRoomTypeAsync()).Select(MapToDto).ToList();
        }

        private static DictionaryDto MapToDto(RoomTypeDb roomTypeDb) => Map<DictionaryDto>(roomTypeDb);

        private static T Map<T>(RoomTypeDb roomTypeDb) where T : DictionaryDto, new()
            => new()
            {
                Id = roomTypeDb.Id,
                Code = roomTypeDb.Code,
                Value = roomTypeDb.Value
            };
    }
}
