using backend_smarthome.DTO;
using backend_smarthome.Service.DeviceTypes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/device_type")]
    [ApiController]
    //[Authorize]
    public class DeviceTypeController : ControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService;
        public DeviceTypeController(IDeviceTypeService deviceTypeService)
        {
            _deviceTypeService = deviceTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Return device type list")]
        public async Task<ActionResult<IList<DictionaryDto>>> GetDeviceypes()
        {
            var result = await _deviceTypeService.GetDeviceTypeAsync();
            return Ok(result);
        }
    }
}
