using MediatR;
using MediatrDemo.Logic.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Commands.Flights
{
    public class CreateFlightLegCommand : IRequest<int>
    {
        public int FlightBookingId { get; set; }
        public string Reference { get; set; }
        public string FromIata { get; set; }
        public string ToIata { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }

    public class CreateFlightLegCommandHandler : IRequestHandler<CreateFlightLegCommand, int>
    {
        private readonly IFlightLegRepository repository;

        public CreateFlightLegCommandHandler(IFlightLegRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateFlightLegCommand request, CancellationToken cancellationToken)
        {
            var id = await repository.CreateAsync(request);

            return id;
        }
    }
}
