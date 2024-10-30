using backend_smarthome.DAL.Configuration;
using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Exceptions;
using backend_smarthome.Helpers;
using backend_smarthome.Repository.Apartments;
using backend_smarthome.Repository.Devices;
using backend_smarthome.Repository.Rooms;
using EHome.Keycloak.Client.Models.User;
using System.Collections.Generic;

namespace backend_smarthome.Service.Devices
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IRoomRepository _roomRepository;

        public DeviceService(IDeviceRepository deviceRepository, IRoomRepository roomRepository)
        {
            _deviceRepository = deviceRepository;
            _roomRepository = roomRepository;
        }

        public async Task AddAsync(AddDeviceDto deviceDto, int roomId)
        {
            var roomDb = await _roomRepository.FindByIdAsync(roomId);
            if (roomDb == null)
            {
                throw new EntityNotFoundException(roomId, "Room");
            }

            var serialNumberExists = await _deviceRepository.CheckIfSerialNumberExistsAsync(deviceDto.SerialNumber);
            if (serialNumberExists)
            {
                throw new SerialNumberAlreadyExistsException(deviceDto.SerialNumber);
            }

            var deviceSymbol = UnitSymbolExtensions.GetSymbolByDeviceTypeId(deviceDto.DeviceTypeId);

            var deviceDb = MapToDeviceDb(deviceDto);
            var newDeviceDb = new DeviceDb
            {
                Name = deviceDto.Name,
                Active = true,
                Symbol = deviceSymbol,
                Value = 0.0,
                RoomId = roomId,
                DeviceTypeId = deviceDto.DeviceTypeId,
            };

            await _deviceRepository.AddAsync(newDeviceDb);

            var newDevicesDb = new DevicesDb
            {
                SerialNumber = deviceDto.SerialNumber,
                IsActive = true,
                UserId = deviceDto.UserId,
                DeviceId = newDeviceDb.Id 
            };

            await _deviceRepository.AddDevicesAsync(newDevicesDb);
        }

        public async Task<IList<DeviceDto>> GetDevicesAssignedToRoom(int roomId)
        {
            var deviceDb = await _deviceRepository.GetDevicesAssignedToRoom(roomId);
            return deviceDb.Select(MapToDto).ToList();
        }

        public async Task<bool> RemoveAsync(int deviceId)
        {
            return await _deviceRepository.RemoveAsync(deviceId);
        }

        public async Task<bool> IsSerialNumberAssignedToUserAsync(string serialNumber, Guid userId)
        {
            return await _deviceRepository.IsSerialNumberAssignedToUserAsync(serialNumber, userId);
        }

        public async Task<DeviceDto?> FindByIdAsync(int deviceId)
        {
            return MapToDto(await _deviceRepository.FindByIdAsync(deviceId));
        }

        public async Task AddDevicesAsync(DevicesDto deviceDto, Guid userId)
        {
            var deviceDb = await _deviceRepository.FindByIdAsync(deviceDto.DeviceId.Value);
            if (deviceDb == null)
            {
                throw new EntityNotFoundException(deviceDto.DeviceId.Value, "DeviceId");
            }

            var newDeviceDb = new DevicesDb
            {
                SerialNumber = deviceDto.SerialNumber,
                IsActive = true,
                UserId = userId,
                DeviceId = deviceDb.Id
            };

            await _deviceRepository.AddDevicesAsync(newDeviceDb);
        }

        #region "Private"

        private static DeviceDto MapToDto(DeviceDb deviceDb) => Map<DeviceDto>(deviceDb);

        private static T Map<T>(DeviceDb deviceDb) where T : DeviceDto, new()
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

        private static DeviceDb MapToDeviceDb(AddDeviceDto deviceDto) => new()
        {
            Name = deviceDto.Name,
            DeviceTypeId = deviceDto.DeviceTypeId,
        };
            #endregion
    }
}

