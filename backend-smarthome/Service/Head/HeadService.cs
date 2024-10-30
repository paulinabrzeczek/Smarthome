using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;
using backend_smarthome.Repository.Devices;
using backend_smarthome.Repository.Heads;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.Service.Head
{
    public class HeadService : IHeadService
    {
        private readonly IHeadRepository _headRepository;
        private readonly IDeviceRepository _deviceRepository;
        public HeadService(IHeadRepository headRepository, IDeviceRepository deviceRepository)
        {
            _headRepository = headRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task AddAsync(HeadDto headDto)
        {
            var deviceDb = new DeviceDb
            {
                Name = headDto.Name,
                RoomId = headDto.RoomId,
                Active = headDto.Active,
                Symbol = headDto.Symbol,
                Value = headDto.Value,
                DeviceTypeId = headDto.DeviceTypeId
            };

            await _deviceRepository.AddAsync(deviceDb);

            var headDb = new HeadDb
            {
                Name = headDto.Name,
                IndoorTemp = headDto.IndoorTemp,
                OutdoorTemp = headDto.OutdoorTemp,
                MaxTemp = headDto.MaxTemp,
                MinTemp = headDto.MinTemp,
                RoomId = headDto.RoomId,
                Active = headDto.Active,
                Symbol = headDto.Symbol,
                Value = headDto.Value,
                DeviceTypeId = headDto.DeviceTypeId,
            };

            await _headRepository.AddAsync(headDb);
        }

		public async Task<IList<HeadDto>> GetHeadsByRoomIdAsync(int roomId)
		{
			var headDb = await _headRepository.GetHeadsByRoomIdAsync(roomId);
			return headDb.Select(MapToDto).ToList();
		}

		#region "Mappers"
		private static HeadDto MapToDto(HeadDb headDb) => Map<HeadDto>(headDb);

        private static T Map<T>(HeadDb headDb) where T : HeadDto, new()
		  => new()
		  {
			  Name = headDb.Name,
			  IndoorTemp = headDb.IndoorTemp,
			  MaxTemp = headDb.MaxTemp,
			  MinTemp = headDb.MinTemp,
              RoomId = headDb.RoomId,
              Active = headDb.Active,
              Symbol = headDb.Symbol,
              Value = headDb.Value,
              DeviceTypeId = headDb.DeviceTypeId,
		  };
		#endregion
	}
}
