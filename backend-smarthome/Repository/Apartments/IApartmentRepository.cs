using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace backend_smarthome.Repository.Apartments
{
    public interface IApartmentRepository
    {
        Task AddAsync(ApartmentDb apartmentDb);
        Task UpdateAsync(ApartmentDb apartmentDb);
        Task<ApartmentDb?> FindByIdAsync(int apartmentId);
        Task<IList<ApartmentDb>> GetApartments();
        Task<bool> CheckIfExistsAsync(int apartmentId);
        Task<bool> RemoveAsync(int apartmentId);
        Task<bool> CheckIfNameExistsAsync(string name);
        Task<IList<ApartmentDb>> GetApartmentsByUserIdAsync(Guid userId);
    }
}
