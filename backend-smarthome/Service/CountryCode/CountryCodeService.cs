using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Repository.CountryCode;

namespace backend_smarthome.Service.CountryCode
{
    public class CountryCodeService : ICountryCodeService
    {
        private readonly ICountryCodeRepository _countryCodeRepository;
        public CountryCodeService(ICountryCodeRepository countryCodeRepository)
        {
            _countryCodeRepository = countryCodeRepository;
        }

        public async Task<IList<DictionaryDto>> GetCountryCodesAsync()
        {
            return (await _countryCodeRepository.GetAllCountryCodesAsync()).Select(MapToDto).ToList();
        }

        private static DictionaryDto MapToDto(CountryDb deviceTypeDb) => Map<DictionaryDto>(deviceTypeDb);

        private static T Map<T>(CountryDb deviceTypeDb) where T : DictionaryDto, new()
            => new()
            {
                Id = deviceTypeDb.Id,
                Code = deviceTypeDb.Code,
                Value = deviceTypeDb.Value
            };

    }
}
