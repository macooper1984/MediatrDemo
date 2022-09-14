using MediatrDemo.Logic.Commands.Flights;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Repositories
{
    public interface IFlightLegRepository
    {
        Task<int> CreateAsync(CreateFlightLegCommand request);
    }
}
