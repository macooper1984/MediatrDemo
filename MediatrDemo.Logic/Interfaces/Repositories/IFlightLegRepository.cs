using MediatrDemo.Logic.Usecases.FlightLegs.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Interfaces.Repositories
{
    public interface IFlightLegRepository
    {
        Task<int> CreateAsync(CreateFlightLegCommand request);

        Task<List<CreateFlightLegCommand>> GetByIdAsync(int flightBookingId);
    }
}
