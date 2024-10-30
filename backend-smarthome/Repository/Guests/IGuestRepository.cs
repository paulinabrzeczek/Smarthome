using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.Guests
{
    public interface IGuestRepository
    {
        Task<bool> RemoveAsync(Guid guestId);
        Task<GuestDb?> GetByEmailAsync(string email);
        Task AddAsync(GuestDb guestDb);
        Task<IList<GuestDb>> GetGuestsByApartmentIdAsync(int apartmentId);
        Task UpdateAsync(GuestDb guestDb);
        Task<ApartmentDb?> GetApartmentByGuestEmailAsync(string email);
    }
}
