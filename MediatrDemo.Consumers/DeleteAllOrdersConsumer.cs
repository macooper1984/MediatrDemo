using MassTransit;
using MediatR;
using MediatrDemo.Consumers.Messages;
using MediatrDemo.Logic.Usecases.Orders.Commands;
using Microsoft.Extensions.Logging;

namespace MediatrDemo.Consumers
{
    public class DeleteAllOrdersConsumer : IConsumer<DeleteAllBookingsCommand>
    {
        private readonly IMediator mediator;

        public DeleteAllOrdersConsumer(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Consume(ConsumeContext<DeleteAllBookingsCommand> context)
        {
            var command = new DeleteAllOrdersCommand();
            await mediator.Send(command);
        }
    }
}