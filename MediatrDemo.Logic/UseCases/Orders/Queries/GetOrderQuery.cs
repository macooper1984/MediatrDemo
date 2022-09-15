using MediatR;
using MediatrDemo.Domain.Exceptions;
using MediatrDemo.Logic.Interfaces.Repositories;
using MediatrDemo.Logic.Usecases.Hotels.Queries;
using MediatrDemo.Logic.Usecases.Orders.Commands;
using MediatrDemo.Logic.UseCases.FlightBookings.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Usecases.Orders.Queries
{
    public record GetOrderQuery : IRequest<CreateOrderCommand>
    {
        public int Id { get; }

        public GetOrderQuery(int id)
        {
            Id = id;
        }
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, CreateOrderCommand>
    {
        private readonly IOrderRepository repository;
        private readonly IMediator mediator;

        public GetOrderQueryHandler(
            IOrderRepository repository,
            IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }
        public async Task<CreateOrderCommand> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);

            if (result == null)
            {
                throw new NotFoundException();
            }

            result.HotelBookings = await mediator.Send(new GetHotelBookingsQuery(request.Id));
            result.FlightBookings = await mediator.Send(new GetFlightBookingsQuery(request.Id));

            return result;
        }
    }
}
