using backend_smarthome.DTO;

namespace backend_smarthome.Service.Head
{
    public interface IHeadService
    {
        Task AddAsync(HeadDto headDto);

		Task<IList<HeadDto>> GetHeadsByRoomIdAsync(int roomId);
	}
}
