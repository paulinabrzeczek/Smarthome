using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Service.Apartments;
using backend_smarthome.Service.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/apartments")]
    [ApiController]
    // [Authorize]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly IGuestService _guestService;
        public ApartmentController(IApartmentService apartmentService, IGuestService guestService)
        {
            _apartmentService = apartmentService;
            _guestService = guestService;
        }

        [HttpGet("{apartmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Return apartment with id")]
        public async Task<ActionResult<ApartmentDto>> FindById(int apartmentId)
        {
            return Ok(await _apartmentService.FindByIdAsync(apartmentId));
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add apartment")]
        public async Task<ActionResult> AddApartment(AddApartmentDto addApartmentDto, Guid userId)
        {
            await _apartmentService.AddAsync(addApartmentDto, userId);
            return Ok();
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get userId")]
        public async Task<IActionResult> GetApartmentsByUserId(Guid userId)
        {
            var apartments = await _apartmentService.GetApartmentsByUserIdAsync(userId);
            if (apartments == null)
            {
                return NotFound();
            }
            return Ok(apartments);
        }

        [HttpPut("{apartmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Modify apartment")]
        public async Task<ActionResult> UpdateApartment(UpdateApartmentDto updateApartmentDto, int apartmentId)
        {
            await _apartmentService.UpdateAsync(updateApartmentDto, apartmentId);
            return Ok("Apartment updated successfully.");
        }

        [HttpDelete("{apartmentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete apartment")]
        public async Task<ActionResult> RemoveApartment(int apartmentId)
        {
            return await _apartmentService.RemoveAsync(apartmentId) ? NoContent() : NotFound();
        }

        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation("Return apartment assigned to guest")]
        public async Task<ActionResult<ApartmentDto[]>> GetApartmentByGuestEmail(string email)
        {
            var apartment = await _guestService.GetApartmentByGuestEmailAsync(email);

            if (apartment == null)
            {
                return Ok(Array.Empty<ApartmentDto>());
            }

            return Ok(new[] { apartment });
        }
    }
}
