using backend_smarthome.DTO;

namespace backend_smarthome.Service.SSE
{
    public interface IEventStreamService
    {
        Task StreamEventsAsync(Guid userId, HttpResponse response);
        Task SetHeatingSetpointAsync(string id, HeatingSetpointDto heatingSetpointDto);
    }
}
