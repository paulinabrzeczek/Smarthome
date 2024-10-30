using System.Net;

namespace backend_smarthome.Exceptions
{
    public class SerialNumberAlreadyExistsException : EHomeException
    {
        public SerialNumberAlreadyExistsException(string serialNumber)
            : base($"Serial number '{serialNumber}' already exist in database.", HttpStatusCode.InternalServerError) { }
    }
}
