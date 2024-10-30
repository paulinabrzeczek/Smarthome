using backend_smarthome.DTO;
using backend_smarthome.Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add user")]
        public async Task<ActionResult> AddApartment(UserDto userDto, Guid userId)
        {
            await _userService.AddAsync(userDto, userId);
            return Ok();
        }
    }
}
