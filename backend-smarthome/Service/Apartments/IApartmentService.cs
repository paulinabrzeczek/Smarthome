using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;

namespace backend_smarthome.Service.Apartments
{
    public interface IApartmentService
    {
        Task AddAsync(AddApartmentDto addApartmentDto, Guid userId);
        Task UpdateAsync(UpdateApartmentDto updateApartmentDto, int apartmentId);
        Task<ApartmentDto?> FindByIdAsync(int apartmentId);
        Task<IList<ApartmentDto>> GetApartmentsByUserIdAsync(Guid userId);
        Task<bool> RemoveAsync(int apartmentId);
    }
}
