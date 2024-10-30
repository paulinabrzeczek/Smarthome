using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Repository.Guests;

namespace backend_smarthome.Service.Guests
{
    public interface IGuestService
    {
        Task<bool> RemoveAsync(Guid guestId);
        Task<IList<GuestDto>> GetGuestByApartmentIdAsync(int apartmentId);
        Task AddGuestToApartmentAsync(int apartmentId, AddGuestDto addGuestDto);
        Task<ApartmentDto?> GetApartmentByGuestEmailAsync(string email);
    }
}
