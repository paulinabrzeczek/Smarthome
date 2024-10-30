using backend_smarthome.DAL.Entity;

namespace backend_smarthome.Repository.CountryCode
{
    public interface ICountryCodeRepository
    {
        Task<IList<CountryDb>> GetAllCountryCodesAsync();
        Task<CountryDb?> GetByIdAsync(int countryId);
    }
}
