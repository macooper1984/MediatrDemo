using MediatR;
using MediatrDemo.Domain.Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines
{
    public class LoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var str = $"{DateTime.UtcNow.ToShortTimeString()} - {CorrelationService.TraceId} - Processing {request.GetType()}";

            await File.AppendAllLinesAsync("c:/code/pipelineOutput.txt", new string[] { str });

            return await next.Invoke();
        }
    }
}
