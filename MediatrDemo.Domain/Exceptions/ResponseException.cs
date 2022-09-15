using System;
using System.Net;

namespace MediatrDemo.Domain.Exceptions
{
    public abstract class ResponseException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }
    }
}