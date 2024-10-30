using backend_smarthome.DTO;
using backend_smarthome.Service.RoomTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/room_type")]
    [ApiController]
    //[Authorize]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Return room type list")]
        public async Task<ActionResult<IList<DictionaryDto>>> GetRoomTypes()
        {
            var result = await _roomTypeService.GetRoomTypeAsync();
            return Ok(result);
        }
    }
}
