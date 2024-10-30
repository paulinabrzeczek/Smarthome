using backend_smarthome.DTO;
using backend_smarthome.Service.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/guest")]
    [ApiController]
    //[Authorize]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet("{apartmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get guests assigned to apartment")]
        public async Task<ActionResult<IList<GuestDto>>> GetGuestAssignedToApartment(int apartmentId)
        {
            var guests = await _guestService.GetGuestByApartmentIdAsync(apartmentId);
            return Ok(guests);
        }

        [HttpDelete("{guestId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete guest")]
        public async Task<ActionResult> RemoveApartment(Guid guestId)
        {
            return await _guestService.RemoveAsync(guestId) ? NoContent() : NotFound();
        }

        [HttpPut("{apartmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Assign guest to apartment")]
        public async Task<ActionResult<IList<GuestDto>>> AddGuestToApartment(int apartmentId, [FromBody] AddGuestDto addGuestDto)
        {
            await _guestService.AddGuestToApartmentAsync(apartmentId, addGuestDto);
            var guests = await _guestService.GetGuestByApartmentIdAsync(apartmentId);
            return Ok(guests);
        }
    }
}
