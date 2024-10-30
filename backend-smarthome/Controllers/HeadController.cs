using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Service.Head;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/head")]
    [ApiController]
    public class HeadController : ControllerBase
    {
        private readonly IHeadService _headService;
        public HeadController(IHeadService headService)
        {
            _headService = headService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add head to database and device")]
        public async Task<ActionResult> AddHead(HeadDto headDto)
        {
            await _headService.AddAsync(headDto);
            return Ok();
        }


		[HttpGet("{roomId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[SwaggerOperation("Get heads by room")]
		public async Task<ActionResult<IList<HeadDto>>> GetHeadsAssignedToRooms(int roomId)
		{
			var guests = await _headService.GetHeadsByRoomIdAsync(roomId);
			return Ok(guests);
		}
	}
}
