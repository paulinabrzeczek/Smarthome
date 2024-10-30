using backend_smarthome.DTO;

namespace backend_smarthome.Service.Rooms
{
    public interface IRoomService
    {
        Task AddAsync(UpdateRoomDto updateRoomDto, int apartmentId);
        Task UpdateAsync(UpdateRoomDto updateRoomDto, int roomId);
        Task<RoomDto?> FindByIdAsync(int roomId);
        Task<bool> RemoveAsync(int roomId);
        Task<int> CountDevicesInApartmentAsync(int apartmentId);
    }
}
