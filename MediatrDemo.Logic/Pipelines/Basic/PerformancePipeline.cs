using MediatR;
using MediatrDemo.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines.Basic
{
    internal class PerformancePipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (var timer = new DodgyTimer(request.GetType().Name))
            {
                return await next.Invoke();
            }                
        }
    }
}
