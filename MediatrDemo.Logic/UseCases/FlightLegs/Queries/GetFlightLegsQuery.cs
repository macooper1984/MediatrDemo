using MediatR;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Interfaces.Repositories;
using MediatrDemo.Logic.Usecases.FlightLegs.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Usecases.FlightLegs.Queries
{
    public class GetFlightLegsQuery : IQuery<List<CreateFlightLegCommand>>
    {
        public GetFlightLegsQuery(int flightBookingId)
        {
            FlightBookingId = flightBookingId;
        }

        public int FlightBookingId { get; }

        public string CacheKey => $"GetFlightLegs:{FlightBookingId}";
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
