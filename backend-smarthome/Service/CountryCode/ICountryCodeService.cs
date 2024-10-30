using backend_smarthome.DTO;

namespace backend_smarthome.Service.CountryCode
{
    public interface ICountryCodeService
    {
        Task<IList<DictionaryDto>> GetCountryCodesAsync();
    }
}
