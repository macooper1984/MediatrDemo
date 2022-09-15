using MediatR;
using MediatrDemo.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines
{
    public class CachingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cacheKey = request.CacheKey;

            if (DodgyCache.HasKey(cacheKey))
            {
                return await Task.FromResult(DodgyCache.GetByKey<TResponse>(cacheKey));
            }
            else
            {
                var result = await next.Invoke();

                DodgyCache.Store(cacheKey, result);

                return result;
            }
        }
    }
}
