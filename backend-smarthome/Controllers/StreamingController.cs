using backend_smarthome.DTO;
using backend_smarthome.Service.Devices;
using backend_smarthome.Service.SSE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace backend_smarthome.Controllers
{
    [Route("api/sse")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private readonly IEventStreamService _eventStreamService;

        public StreamingController(IEventStreamService eventStreamService)
        {
            _eventStreamService = eventStreamService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetEventStreams(Guid userId)
        {
            await _eventStreamService.StreamEventsAsync(userId, Response);
            return new EmptyResult();
        }

        [HttpPost("devices/{id}")]
        public async Task<ActionResult> SetHeatingSetpoint(string id, [FromBody] HeatingSetpointDto heatingSetpointDto)
        {
            if (heatingSetpointDto == null)
            {
                return BadRequest("Invalid data.");
            }

            await _eventStreamService.SetHeatingSetpointAsync(id, heatingSetpointDto);

            return Ok();
        }
    }

}
