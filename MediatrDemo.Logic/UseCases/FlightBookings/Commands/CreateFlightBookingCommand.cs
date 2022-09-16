using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatrDemo.Logic.Usecases.FlightLegs.Commands;
using MediatrDemo.Logic.Interfaces.Repositories;

namespace MediatrDemo.Logic.Usecases.FlightBookings.Commands
{
    public class CreateFlightBookingCommand : ICommand<int>
    {
        public int Id { get; set; }
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
