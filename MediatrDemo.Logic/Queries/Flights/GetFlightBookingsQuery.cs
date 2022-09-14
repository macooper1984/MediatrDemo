using MediatR;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Queries.Hotels;
using MediatrDemo.Logic.Repositories;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Queries.Flights
{
    public class GetFlightBookingsQuery : IRequest<List<CreateFlightBookingCommand>>
    {
        public GetFlightBookingsQuery(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
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
