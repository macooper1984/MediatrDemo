using MediatR;
using MediatrDemo.Logic.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Usecases.Orders.Commands
{
    public class DeleteAllOrdersCommand : IRequest
    {
    }

    public class DeleteAllOrdersCommandHandler : IRequestHandler<DeleteAllOrdersCommand>
    {
        private readonly IOrderRepository repository;

        public DeleteAllOrdersCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteAllOrdersCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAllAsync();

            DodgyEventPublisher.PublishEvent(new AllOrdersDeletedEvent());

            return new Unit();
        }
    }
}
