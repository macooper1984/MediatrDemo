using MediatrDemo.Domain;
using MediatrDemo.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MediatrDemo.Api.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ResponseException ex)
            {
                await DodgyLogger.LogAsync($"Exception: {ex.Message}");
                await HandleResponseException(context, ex);
            }
        }

        private async Task HandleResponseException(HttpContext context, ResponseException ex)
        {
            var statusCode = ex.StatusCode;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var body = new ErrorResponse()
            {
                StatusCode = (int)statusCode,
                StatusCodeName = statusCode.ToString(),
                Message = ex.Message,
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(body));
        }
    }
}
