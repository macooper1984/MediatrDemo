using MediatR;

namespace MediatrDemo.Logic
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
