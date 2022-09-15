using System.Collections.Generic;

namespace MediatrDemo.Domain
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public string StatusCodeName { get; set; }

        public string Message { get; set; }
    }
}
