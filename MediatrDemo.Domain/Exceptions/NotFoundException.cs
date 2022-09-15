using System.Net;

namespace MediatrDemo.Domain.Exceptions
{
    public class NotFoundException : ResponseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
