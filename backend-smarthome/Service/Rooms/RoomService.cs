using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Exceptions;
using backend_smarthome.Repository.Apartments;
using backend_smarthome.Repository.Rooms;

namespace backend_smarthome.Service.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IApartmentRepository _apartmentRepository;
        public RoomService(IRoomRepository roomRepository, IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
            _roomRepository = roomRepository;
        }

        public async Task AddAsync(UpdateRoomDto updateRoomDto, int apartmentId)
        {
            var apartmentDb = await _apartmentRepository.FindByIdAsync(apartmentId);
            if(apartmentDb == null )
            {
                throw new EntityNotFoundException(apartmentId, "Apartment");
            }

            var roomDb = MapToUpdateRoomDb(updateRoomDto);
            var newRoomDb = new RoomDb
            {
                Name = updateRoomDto.Name,
                RoomTypeId = updateRoomDto.RoomTypeId,
                ApartmentId = apartmentId
            };

            await _roomRepository.AddAsync(newRoomDb);
        }

        public async Task<RoomDto?> FindByIdAsync(int roomId)
        {
            return MapToDto(await _roomRepository.FindByIdAsync(roomId));
        }

        public async Task UpdateAsync(UpdateRoomDto updateRoomDto, int roomId)
        {
            var roomDb = await _roomRepository.FindByIdAsync(roomId);
            if (roomDb == null)
            {
                throw new EntityNotFoundException(roomId, "Room");
            }

            var newUpdatedRoomDb = MapToUpdateRoomDb(updateRoomDto);
            roomDb.Name = newUpdatedRoomDb.Name;
            roomDb.RoomTypeId = newUpdatedRoomDb.RoomTypeId;

            await _roomRepository.UpdateAsync(roomDb);
        }

        public async Task<bool> RemoveAsync(int roomId)
        {
            return await _roomRepository.RemoveAsync(roomId);
        }
        public async Task<int> CountDevicesInApartmentAsync(int apartmentId)
        {
            return await _roomRepository.CountDevicesInApartmentAsync(apartmentId);
        }

        #region "Private"
        private static RoomDto MapToDto(RoomDb roomDb)
        {
            return Map<RoomDto>(roomDb);
        }
        private static RoomDb MapToRoomDb(RoomDto roomDto) => new()
        {
            Id = roomDto.Id,
            Name = roomDto.Name,
            ApartmentId = roomDto.ApartmentId,
        };
        private static T Map<T>(RoomDb roomDb) where T : RoomDto, new()
            => new()
            {
                Id = roomDb.Id,
                Name = roomDb.Name,
                ApartmentId = roomDb.ApartmentId,
                Devices = roomDb.Devices != null ? MapToDeviceDto(roomDb.Devices) : null
            };
        private static ICollection<DeviceDto> MapToDeviceDto(ICollection<DeviceDb> devicesDb)
        {
            return devicesDb.Select(deviceDb => MapDevice<DeviceDto>(deviceDb)).ToList();
        }
        private static T MapDevice<T>(DeviceDb deviceDb) where T : DeviceDto, new()
           => new()
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
           };

        private static RoomDb MapToUpdateRoomDb(UpdateRoomDto updateRoomDto) => new()
        {
            Name = updateRoomDto.Name,
            RoomTypeId = updateRoomDto.RoomTypeId,
        };
        #endregion
    }
}
