using System.Net;

namespace backend_smarthome.Exceptions
{
    public abstract class EHomeException : HttpException
    {
        protected EHomeException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message, statusCode) { }
    }
}
