using EHome.Keycloak.Client.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHome.Keycloak.Client
{
    public interface IKeycloakClient
    {
        Task<IList<User>> GetUsersAsync(string accessToken);
        Task<User> GetUserAsync(string accessToken, string userId);
        Task<string> GetAccessToken();
    }
}
