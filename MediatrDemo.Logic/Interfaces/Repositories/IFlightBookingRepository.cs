using MediatrDemo.Logic.Usecases.FlightBookings.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Interfaces.Repositories
{
    public interface IFlightBookingRepository
    {
        Task<int> CreateAsync(CreateFlightBookingCommand request);

        Task<List<CreateFlightBookingCommand>> GetByIdAsync(int orderId);
    }
}
