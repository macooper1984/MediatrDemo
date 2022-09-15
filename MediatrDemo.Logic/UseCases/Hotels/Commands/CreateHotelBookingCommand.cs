using MediatR;
using MediatrDemo.Logic.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.UseCases.Hotels.Commands
{
    public class CreateHotelBookingCommand : IRequest<int>
    {
        public int OrderId { get; set; }

        public string HotelName { get; set; }

        public string RoomType { get; set; }

        public int NumberOfBeds { get; set; }

        public int TotalCost { get; set; }
    }

    public class CreateHotelBookingCommandHandler : IRequestHandler<CreateHotelBookingCommand, int>
    {
        private readonly IHotelBookingRepository repository;

        public CreateHotelBookingCommandHandler(IHotelBookingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateHotelBookingCommand request, CancellationToken cancellationToken)
        {
            var id = await repository.CreateAsync(request);

            return id;
        }
    }
}
