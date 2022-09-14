using MediatR;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Commands.Hotels;
using MediatrDemo.Logic.Queries.Hotels;
using MediatrDemo.Logic.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace MediatrDemo.Logic.Queries.Flights
{
    public class GetFlightLegsQuery : IRequest<List<CreateFlightLegCommand>>
    {
        public GetFlightLegsQuery(int flightBookingId)
        {
            FlightBookingId = flightBookingId;
        }

        public int FlightBookingId { get; }


    }

    public class GetFlightLegsQueryHandler : IRequestHandler<GetFlightLegsQuery, List<CreateFlightLegCommand>>
    {
        private readonly IFlightLegRepository repository;

        public GetFlightLegsQueryHandler(
            IFlightLegRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<CreateFlightLegCommand>> Handle(GetFlightLegsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.FlightBookingId);

            return result;
        }
    }
}
