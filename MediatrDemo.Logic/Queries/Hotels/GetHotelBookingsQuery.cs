using MediatR;
using MediatrDemo.Logic.Commands;
using MediatrDemo.Logic.Commands.Hotels;
using MediatrDemo.Logic.Queries.Flights;
using MediatrDemo.Logic.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace MediatrDemo.Logic.Queries.Hotels
{
    public class GetHotelBookingsQuery : IRequest<List<CreateHotelBookingCommand>>
    {
        public GetHotelBookingsQuery(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }

    public class GetHotelBookingsQueryHandler : IRequestHandler<GetHotelBookingsQuery, List<CreateHotelBookingCommand>>
    {
        private readonly IHotelBookingRepository repository;
        private readonly IMediator mediator;

        public GetHotelBookingsQueryHandler(
            IHotelBookingRepository repository,
            IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }
        public async Task<List<CreateHotelBookingCommand>> Handle(GetHotelBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.OrderId);

            return result;
        }
    }
}
