using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Repository.Users;
using System.Security.Cryptography;

namespace backend_smarthome.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(UserDto userDto, Guid userId)
        {
            if (!await _userRepository.CheckIfExistsAsync(userId))
            {
                var userDb = MapToUserDb(userDto);
                var newUserDb = new UserDb
                {
                    Id = userId,
                    Username = userDb.Username,
                    Email = HashMail(userDto)
                };

                await _userRepository.AddAsync(newUserDb);
            }
        }
        public string HashMail(UserDto userdto)
        {
            string emailHash;
            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    string publicKey = rsa.ToXmlString(false);
                    byte[] originalBytes = System.Text.Encoding.UTF8.GetBytes(userdto.Email);
                    byte[] encryptedBytes = rsa.Encrypt(originalBytes, false);
                    emailHash = Convert.ToBase64String(encryptedBytes);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
                return emailHash;
            }
        }

    #region "Private"

    private static UserDto MapToDto(UserDb userDb)
        {
            return Map<UserDto>(userDb);
        }

        private static UserDb MapToUserDb(UserDto userDto) => new()
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Email = userDto.Email
        };

        private static T Map<T>(UserDb userDb) where T : UserDto, new()
            => new()
            {
                Id = userDb.Id,
                Username = userDb.Username,
                Email = userDb.Email
            };

        #endregion
    }
}
