using backend_smarthome.DTO;
using backend_smarthome.Service.Devices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/device")]
    [ApiController]
    //[Authorize]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpDelete("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete device")]
        public async Task<ActionResult> RemoveApartment(int deviceId)
        {
            return await _deviceService.RemoveAsync(deviceId) ? NoContent() : NotFound();
        }

        [HttpGet("room/{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get device assigned to room")]
        public async Task<ActionResult> GetDeviceByRoomId(int roomId)
        {
            var devices = await _deviceService.GetDevicesAssignedToRoom(roomId);
            return devices == null ? NotFound() : Ok(devices);
        }

        [HttpGet("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Return device with id")]
        public async Task<ActionResult<DeviceDto>> FindById(int deviceId)
        {
            return Ok(await _deviceService.FindByIdAsync(deviceId));
        }

        [HttpPost("{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add device")]
        public async Task<ActionResult> AddDevice(AddDeviceDto deviceDto, int roomId)
        {
            await _deviceService.AddAsync(deviceDto, roomId);
            return Ok();
        }

        [HttpPost("assign-device/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Assign device to user")]
        public async Task<ActionResult> AssignDevice(DevicesDto devicesDto, Guid userId)
        {
            await _deviceService.AddDevicesAsync(devicesDto, userId);
            return Ok();
        }

    }
}
