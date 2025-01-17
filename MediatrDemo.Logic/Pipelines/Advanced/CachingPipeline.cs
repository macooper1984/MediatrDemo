﻿using MediatR;
using MediatrDemo.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines.Advanced
{
    public class CachingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cacheKey = request.CacheKey;

            if (DodgyCache.HasKey(cacheKey))
            {
                await DodgyLogger.LogAsync($"Returning result from Cache - {request.GetType().Name}");
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
