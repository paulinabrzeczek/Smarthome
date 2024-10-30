using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Exceptions;
using backend_smarthome.Repository.Apartments;
using backend_smarthome.Repository.CountryCode;
using backend_smarthome.Repository.Users;
using System.Net;

namespace backend_smarthome.Service.Apartments
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ICountryCodeRepository _countryCodeRepository;
        private readonly IUserRepository _userRepository;
        public ApartmentService(IApartmentRepository apartmentRepository, ICountryCodeRepository countryCodeRepository, IUserRepository userRepository)
        {
            _apartmentRepository = apartmentRepository;
            _countryCodeRepository = countryCodeRepository;
            _userRepository = userRepository;
        }

        public async Task AddAsync(AddApartmentDto addApartmentDto, Guid userId)
        {
            if (!await _apartmentRepository.CheckIfNameExistsAsync(addApartmentDto.Name))
            {

                var countryDb = await _countryCodeRepository.GetByIdAsync(addApartmentDto.Address.Country.Id);
                if (countryDb == null)
                {
                    throw new InvalidOperationException("The specified country does not exist.");
                }

                var userExists = await _userRepository.CheckIfExistsAsync(userId);
                if (!userExists)
                {
                    var newUser = new UserDb
                    {
                        Id = userId,
                    };
                    await _userRepository.AddAsync(newUser);
                }

                var apartmentDb = MapToAddApartmentDb(addApartmentDto);
                var newApartmentDb = new ApartmentDb
                {
                    Name = apartmentDb.Name,
                    Address = new AddressDb
                    {
                        CountryId = countryDb.Id,
                        City = apartmentDb.Address.City,
                        Postcode = apartmentDb.Address.Postcode,
                        Street = apartmentDb.Address.Street,
                        BuildingNumber = apartmentDb.Address.BuildingNumber,
                        FlatNumber = apartmentDb.Address.FlatNumber,
                        ApartmentId = apartmentDb.Address.ApartmentId,
                        CountryCode = countryDb.Code,
                        Country = countryDb
                    },
                    UserId = userId
                };

                await _apartmentRepository.AddAsync(newApartmentDb);
            }
        }

        public async Task<ApartmentDto?> FindByIdAsync(int apartmentId)
        {
            return MapToDto(await _apartmentRepository.FindByIdAsync(apartmentId));
        }

        public async Task UpdateAsync(UpdateApartmentDto updateApartmentDto, int apartmentId)
        {
            var apartmentDb = await _apartmentRepository.FindByIdAsync(apartmentId);
            if(apartmentDb == null)
            {
                throw new EntityNotFoundException(apartmentId, "Apartment");
            }

            apartmentDb.Name = updateApartmentDto.Name;

            if (updateApartmentDto.Address != null)
            {
                apartmentDb.Address ??= new AddressDb();

                apartmentDb.Address.CountryId = updateApartmentDto.Address.CountryId;
                apartmentDb.Address.City = updateApartmentDto.Address.City;
                apartmentDb.Address.Postcode = updateApartmentDto.Address.Postcode;
                apartmentDb.Address.Street = updateApartmentDto.Address.Street;
                apartmentDb.Address.BuildingNumber = updateApartmentDto.Address.BuildingNumber;
                apartmentDb.Address.FlatNumber = updateApartmentDto.Address.FlatNumber;
            }

            await _apartmentRepository.UpdateAsync(apartmentDb);
        }

        public async Task<IList<ApartmentDto>> GetApartmentsByUserIdAsync(Guid userId)
        {
            var apartmentDb = await _apartmentRepository.GetApartmentsByUserIdAsync(userId);
            return apartmentDb.Select(MapToDto).ToList();
        }

        public async Task<bool> RemoveAsync(int apartmentId)
        {
            return await _apartmentRepository.RemoveAsync(apartmentId);
        }

        #region "Private"
        private static ApartmentDto MapToDto(ApartmentDb apartmentDb)
        {
            return Map<ApartmentDto>(apartmentDb);
        }

        private static ApartmentDb MapToApartmentDb(ApartmentDto apartmentDto) => new()
        {
            Id = apartmentDto.Id,
            Name = apartmentDto.Name,
            Address = new AddressDb
            {
                Id = apartmentDto.Id,
                BuildingNumber = apartmentDto.Address.BuildingNumber,
                Country = apartmentDto.Address.Country != null ? new CountryDb
                {
                    Id = apartmentDto.Address.Country.Id,
                    Code = apartmentDto.Address.Country.Code,
                    Value = apartmentDto.Address.Country.Value
                } : null,
                City = apartmentDto.Address.City,
                Postcode = apartmentDto.Address.Postcode,
                Street = apartmentDto.Address.Street,
                FlatNumber = apartmentDto.Address.FlatNumber,
                CountryId = apartmentDto.Address.CountryId,
            },
            UserId = apartmentDto.UserId,
            User = new UserDb
            {
                Id = apartmentDto.User.Id,
                Username = apartmentDto.User.Username,
            }
        };

        private static T Map<T>(ApartmentDb apartmentDb) where T : ApartmentDto, new()
            => new()
            {
                Id = apartmentDb.Id,
                Name = apartmentDb.Name,
                Address = apartmentDb.Address != null ? new AddressDto
                {
                    BuildingNumber = apartmentDb.Address.BuildingNumber,
                    Country = apartmentDb.Address.Country != null ? new DictionaryDto
                    {
                        Id = apartmentDb.Address.Country.Id,
                        Code = apartmentDb.Address.Country.Code,
                        Value = apartmentDb.Address.Country.Value
                    } : null,
                    City = apartmentDb.Address.City,
                    Postcode = apartmentDb.Address.Postcode,
                    Street = apartmentDb.Address.Street,
                    FlatNumber = apartmentDb.Address.FlatNumber,
                } : null,
                AddressId = apartmentDb.Address.Id,
                UserId = apartmentDb.UserId,
                User = apartmentDb.User != null ? new UserDto
                {
                    Id = apartmentDb.User.Id,
                    Username = apartmentDb.User.Username,
                } : null,
                Rooms = apartmentDb.Rooms != null ? MapToRoomDto(apartmentDb.Rooms) : null
            };

        private static ICollection<RoomDto> MapToRoomDto(ICollection<RoomDb> roomsDb)
        {
            return roomsDb.Select(roomDb => MapRoom<RoomDto>(roomDb)).ToList();
        }

        private static T MapRoom<T>(RoomDb roomDb) where T : RoomDto, new()
            => new()
            {
                Id = roomDb.Id,
                Name = roomDb.Name,
                ApartmentId = roomDb.ApartmentId,
                RoomType = roomDb.RoomType != null ? new DictionaryDto
                {
                    Id = roomDb.RoomType.Id,
                    Code = roomDb.RoomType.Code,
                    Value = roomDb.RoomType.Value
                } : null,
                Devices = roomDb.Devices?.Select(deviceDb => new DeviceDto
                {
                    Id = deviceDb.Id,
                    Name = deviceDb.Name,
                    RoomId = deviceDb.RoomId,
                    Active = deviceDb.Active,
                    Symbol = deviceDb.Symbol,
                    DeviceTypeId = deviceDb.DeviceTypeId,
                    DeviceType = deviceDb.DeviceType != null ? new DictionaryDto
                    {
                        Id = deviceDb.DeviceType.Id,
                        Code = deviceDb.DeviceType.Code,
                        Value = deviceDb.DeviceType.Value,
                    } : null,
                    SerialNumber = deviceDb.Devices?.SerialNumber
                }).ToList()
            };

        private static ApartmentDb MapToAddApartmentDb(AddApartmentDto addApartmentDto) => new()
        {
            Name = addApartmentDto.Name,
            Address = new AddressDb
            {
                BuildingNumber = addApartmentDto.Address.BuildingNumber,
                City = addApartmentDto.Address.City,
                Postcode = addApartmentDto.Address.Postcode,
                Street = addApartmentDto.Address.Street,
                FlatNumber = addApartmentDto.Address.FlatNumber,  
            },
        };
        #endregion
    }
}
