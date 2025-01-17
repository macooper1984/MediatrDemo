﻿using MediatR;
using MediatrDemo.Logic.Interfaces.Repositories;
using MediatrDemo.Logic.Usecases.FlightBookings.Commands;
using MediatrDemo.Logic.UseCases.Hotels.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Usecases.Orders.Commands
{
    public class CreateOrderCommand : ICommand<int>
    {
        public string Reference { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int TotalCost { get; set; }
        public string Country { get; set; }
        public List<CreateHotelBookingCommand> HotelBookings { get; set; }
        public List<CreateFlightBookingCommand> FlightBookings { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMediator mediator;
        private readonly IOrderRepository repository;

        public CreateOrderCommandHandler(IMediator mediator, IOrderRepository repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderId = await repository.CreateAsync(request);

            foreach (var createHotelBookingCommand in request.HotelBookings)
            {
                createHotelBookingCommand.OrderId = orderId;
                await mediator.Send(createHotelBookingCommand);
            }

            foreach (var createFlightBookingCommand in request.FlightBookings)
            {
                createFlightBookingCommand.OrderId = orderId;
                await mediator.Send(createFlightBookingCommand);
            }

            DodgyEventPublisher.PublishEvent(new FlightBookingCreatedEvent(orderId));

            return orderId;
        }
    }
}
