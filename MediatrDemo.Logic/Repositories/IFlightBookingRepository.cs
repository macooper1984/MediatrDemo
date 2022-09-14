using MediatrDemo.Logic.Commands.Flights;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Repositories
{
    public interface IFlightBookingRepository
    {
        Task<int> CreateAsync(CreateFlightBookingCommand request);
    }
}
