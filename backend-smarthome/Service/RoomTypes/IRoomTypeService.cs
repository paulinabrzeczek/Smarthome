using backend_smarthome.DTO;

namespace backend_smarthome.Service.RoomTypes
{
    public interface IRoomTypeService
    {
        Task<IList<DictionaryDto>> GetRoomTypeAsync();
    }
}
