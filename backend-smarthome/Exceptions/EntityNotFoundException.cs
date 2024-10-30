using System.Net;

namespace backend_smarthome.Exceptions
{
    public sealed class EntityNotFoundException : EHomeException
    {
        public int EntityEntryId { get; }
        public string EntityId { get; }
        public string EntityName { get; }

        public EntityNotFoundException(int  entityEntryId, string entityName) : base(
            $"Record in entity '{entityName}' with id {entityEntryId} dosen't exist.", HttpStatusCode.NotFound)
        {
            EntityEntryId = entityEntryId;
            EntityName = entityName;
        }

        public EntityNotFoundException(string entityId, string entityName) : base(
            $"Record in entity '{entityName}' with id {entityId} dosen't exist.", HttpStatusCode.NotFound)
        {
            EntityId = entityId;
            EntityName = entityName;
        }

    }
}
