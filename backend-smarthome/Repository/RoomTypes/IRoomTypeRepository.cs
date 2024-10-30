using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.RoomTypes
{
    public interface IRoomTypeRepository
    {
        Task<IList<RoomTypeDb>> GetRoomTypeAsync();
    }
}
