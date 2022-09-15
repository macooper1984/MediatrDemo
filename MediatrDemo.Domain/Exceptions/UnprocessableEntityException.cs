using System.Net;

namespace MediatrDemo.Domain.Exceptions
{
    public class UnprocessableEntityException : ResponseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
    }
}
