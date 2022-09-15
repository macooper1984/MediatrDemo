using MediatR;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Interfaces.Repositories;
using MediatrDemo.Logic.Usecases.FlightBookings.Commands;
using MediatrDemo.Logic.Usecases.FlightLegs.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.UseCases.FlightBookings.Queries
{
    public class GetFlightBookingsQuery : IQuery<List<CreateFlightBookingCommand>>
    {
        public GetFlightBookingsQuery(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }

        public string CacheKey => $"GetFlightBooking:{OrderId}";
    }

    public class GetFlightBookingsQueryHandler : IRequestHandler<GetFlightBookingsQuery, List<CreateFlightBookingCommand>>
    {
        private readonly IFlightBookingRepository repository;
        private readonly IMediator mediator;

        public GetFlightBookingsQueryHandler(
            IFlightBookingRepository repository,
            IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }
        public async Task<List<CreateFlightBookingCommand>> Handle(GetFlightBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.OrderId);

            foreach (var flightBooking in result)
            {
                flightBooking.FlightLegs = await mediator.Send(new GetFlightLegsQuery(flightBooking.Id));
            }

            return result;
        }
    }
}
