using EHome.Keycloak.Client;
using EHome.Keycloak.Client.Models;
using EHome.Keycloak.Client.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Swashbuckle.AspNetCore.Annotations;

namespace backend_smarthome.Controllers
{
    [Route("api/keycloak")]
    [ApiController]
    public class KeycloakController : ControllerBase
    {
        private readonly IKeycloakClient _keycloakClient;
        public KeycloakController(IKeycloakClient keycloakClient)
        {
            _keycloakClient = keycloakClient;
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get list of keycloak users")]
        public async Task<ActionResult<IList<User>>> GetUsers()
        {
            var token = await _keycloakClient.GetAccessToken();
            var users = await _keycloakClient.GetUsersAsync(token);
            return Ok(users);
        }

        [HttpGet("userId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get single user from keycloak")]
        public async Task<ActionResult<IList<User>>> GetUser(string userId)
        {
            var token = await _keycloakClient.GetAccessToken();
            var users = await _keycloakClient.GetUserAsync(token, userId);
            return Ok(users);
        }
    }
}
