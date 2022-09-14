using MediatR;
using MediatrDemo.Logic.Commands;
using MediatrDemo.Logic.Queries.Flights;
using MediatrDemo.Logic.Queries.Hotels;
using MediatrDemo.Logic.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Queries
{
    public record GetOrderQuery:IRequest<CreateOrderCommand>
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

            result.HotelBookings = await mediator.Send(new GetHotelBookingsQuery(request.Id));
            result.FlightBookings = await mediator.Send(new GetFlightBookingsQuery(request.Id));

            return result;
        }
    }
}
