using System.Net;

namespace backend_smarthome.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public HttpException(int httpStatusCode) 
        {
            StatusCode = (HttpStatusCode)httpStatusCode;
        }

        public HttpException(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }
        public HttpException(string message, int httpStatusCode) : base(message)
        {
            StatusCode = (HttpStatusCode)httpStatusCode;
        }

        public HttpException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            StatusCode = httpStatusCode;
        }
    }
}
