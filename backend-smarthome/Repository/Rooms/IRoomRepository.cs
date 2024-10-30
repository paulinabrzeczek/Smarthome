using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.Rooms
{
    public interface IRoomRepository
    {
        Task AddAsync(RoomDb roomDb);
        Task UpdateAsync(RoomDb roomDb);
        Task<RoomDb?> FindByIdAsync(int roomId);
        Task<IList<RoomDb>> GetRoomsAsync();
        Task<bool> CheckIfExistsAsync(int roomId);
        Task<bool> RemoveAsync(int roomId);
        Task<int> CountDevicesInApartmentAsync(int apartmentId);
    }
}
