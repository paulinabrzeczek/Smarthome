using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Exceptions;
using backend_smarthome.Repository.Guests;
using System.Net;

namespace backend_smarthome.Service.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<bool> RemoveAsync(Guid guestId)
        {
            return await _guestRepository.RemoveAsync(guestId);
        }

        public async Task<IList<GuestDto>> GetGuestByApartmentIdAsync(int apartmentId)
        {
            var guestDb = await _guestRepository.GetGuestsByApartmentIdAsync(apartmentId);
            return guestDb.Select(MapToDto).ToList();
        }

        public async Task AddGuestToApartmentAsync(int apartmentId, AddGuestDto addGuestDto)
        {
            var guest = await _guestRepository.GetByEmailAsync(addGuestDto.Email);
            if (guest != null)
            {
                guest.ApartmentId = apartmentId;
                await _guestRepository.UpdateAsync(guest);
            }
            else
            {
                throw new GuestEmailDoesNotExistExistsException(addGuestDto.Email);
            }
        }

        #region "Mappers"
        private static GuestDb MapToGuestDb(GuestDto guestDto) => new()
        {
            Id = guestDto.Id,
            Firstname = guestDto.Firstname,
            Lastname = guestDto.Lastname,
            Email = guestDto.Email,
            ApartmentId = guestDto.ApartmentId
        };

        private static GuestDto MapToDto(GuestDb guestDb) => Map<GuestDto>(guestDb);

        private static T Map<T>(GuestDb guestDb) where T : GuestDto, new()
          => new()
          {
              Id = guestDb.Id,
              Firstname = guestDb.Firstname,
              Lastname = guestDb.Lastname,
              Email = guestDb.Email,
              ApartmentId = guestDb.ApartmentId
          };

        private static GuestDb MapToAddGuestDb(AddGuestDto addGuestDto) => new()
        {
            Email = addGuestDto.Email
        };

        public async Task<ApartmentDto?> GetApartmentByGuestEmailAsync(string email)
        {
            var apartment = await _guestRepository.GetApartmentByGuestEmailAsync(email);

            if (apartment == null)
            {
                return null;
            }

            var apartmentDto = new ApartmentDto
            {
                Id = apartment.Id,
                Name = apartment.Name,
                Address = new AddressDto
                {
                    CountryId = apartment.Address.CountryId,
                    City = apartment.Address.City,
                    Postcode = apartment.Address.Postcode,
                    Street = apartment.Address.Street,
                    BuildingNumber = apartment.Address.BuildingNumber,
                    FlatNumber = apartment.Address.FlatNumber,
                    Country = new DictionaryDto
                    {
                        Id = apartment.Address.Country.Id,
                        Code = apartment.Address.Country.Code,
                        Value = apartment.Address.Country.Value
                    }
                },
                Rooms = apartment.Rooms?.Select(r => new RoomDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    RoomType = new DictionaryDto
                    {
                        Id = r.RoomType.Id,
                        Code = r.RoomType.Code,
                        Value= r.RoomType.Value
                    },
                    ApartmentId = r.ApartmentId,
                    Devices = r.Devices?.Select(d => new DeviceDto
                    {
                        Id = d.Id,
                        Name = d.Name,
                        RoomId = d.RoomId
                    }).ToList()
                }).ToList(),
                User = apartment.User != null ? new UserDto
                {
                    Id = apartment.User.Id,
                    Username = apartment.User.Username
                } : null,
                UserId = apartment.UserId
            };

            return apartmentDto;
        }

        #endregion
    }
}
