using backend_smarthome.DTO;
using backend_smarthome.Service.Rooms;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Return room with id")]
        public async Task<ActionResult<RoomDto>> FindById(int roomId)
        {
            return Ok(await _roomService.FindByIdAsync(roomId));
        }

        [HttpPost("{apartmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add room to apartment")]
        public async Task<ActionResult> AddRoom(UpdateRoomDto updateRoomDto, int apartmentId)
        {
            await _roomService.AddAsync(updateRoomDto, apartmentId);
            return Ok();
        }

        [HttpPut("{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Modify room")]
        public async Task<ActionResult> ModifyRoom(UpdateRoomDto updateRoomDto, int roomId)
        {
            await _roomService.UpdateAsync(updateRoomDto, roomId);
            return Ok();
        }

        [HttpDelete("{roomId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete room")]
        public async Task<ActionResult> RemoveApartment(int roomId)
        {
            return await _roomService.RemoveAsync(roomId) ? NoContent() : NotFound();
        }

        [HttpGet("{apartmentId}/device-count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Count devices assigned to apartments")]
        public async Task<IActionResult> GetDeviceCountAsync(int apartmentId)
        {
            int deviceCount = await _roomService.CountDevicesInApartmentAsync(apartmentId);
            return Ok(new { deviceCount });
        }
    }
}
