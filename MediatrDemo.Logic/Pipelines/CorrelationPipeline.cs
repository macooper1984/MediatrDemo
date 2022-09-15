using MediatR;
using MediatrDemo.Domain.Services;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines
{
    public class CorrelationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (CorrelationService.HasTraceId == false)
            {
                CorrelationService.TraceId = Guid.NewGuid();
            }

            return await next.Invoke();
        }
    }
}
