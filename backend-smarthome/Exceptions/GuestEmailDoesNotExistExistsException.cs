using System.Net;

namespace backend_smarthome.Exceptions
{
    public class GuestEmailDoesNotExistExistsException : EHomeException
    {
        public GuestEmailDoesNotExistExistsException(string email) 
            : base($"Guest with email address '{email}' does not exists.", HttpStatusCode.InternalServerError) { }
    }
}
