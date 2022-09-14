using MediatR;
using MediatrDemo.Logic.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace MediatrDemo.Logic.Commands.Flights
{
    public class CreateFlightBookingCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public string Reference { get; set; }
        public string AirlineName { get; set; }
        public int TotalCost { get; set; }
        public List<CreateFlightLegCommand> FlightLegs { get; set; }
    }

    public class CreateFlightBookingCommandHandler : IRequestHandler<CreateFlightBookingCommand, int>
    {
        private readonly IMediator mediator;
        private readonly IFlightBookingRepository repository;

        public CreateFlightBookingCommandHandler(IMediator mediator, IFlightBookingRepository repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        public async Task<int> Handle(CreateFlightBookingCommand request, CancellationToken cancellationToken)
        {
            var id = await repository.CreateAsync(request);

            foreach (var command in request.FlightLegs)
            {
                command.FlightBookingId = id;
                await mediator.Send(command);
            }

            return id;
        }
    }
}
