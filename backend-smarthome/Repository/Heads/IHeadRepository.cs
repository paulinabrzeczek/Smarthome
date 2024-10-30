using backend_smarthome.DAL.Entity;
using backend_smarthome.DTO;

namespace backend_smarthome.Repository.Heads
{
    public interface IHeadRepository
    {
        Task AddAsync(HeadDb headDb);
        Task<bool> CheckIfExistsAsync(int headId);
		Task<IList<HeadDb>> GetHeadsByRoomIdAsync(int roomId);
	}
}
