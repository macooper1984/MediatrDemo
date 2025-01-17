﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MediatrDemo.Logic.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Usecases.FlightLegs.Commands
{
    public class CreateFlightLegCommand : ICommand<int>
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

    public class CreateFlightLegCommandValidator : AbstractValidator<CreateFlightLegCommand>
    {
        public CreateFlightLegCommandValidator()
        {
            RuleFor(n => n.ToIata).NotEqual("ABC").WithMessage("We don't fly from there");
        }
    }
}
