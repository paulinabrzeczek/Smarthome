using backend_smarthome.DTO;
using backend_smarthome.Service.CountryCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/country_code")]
    [ApiController]
    public class CountryCodeController : ControllerBase
    {
        private readonly ICountryCodeService _countryCodeService;
        public CountryCodeController(ICountryCodeService countryCodeService)
        {
            _countryCodeService = countryCodeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get country codes")]
        public async Task<ActionResult<IList<DictionaryDto>>> GetCountryCodes()
        {
            return Ok(await _countryCodeService.GetCountryCodesAsync());
        }
    }
}
