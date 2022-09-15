using MediatR;

namespace MediatrDemo.Domain
{
    public interface IQuery<TResponse>: IRequest<TResponse>
    {
        string CacheKey { get; }
    }
}
