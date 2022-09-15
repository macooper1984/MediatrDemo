using MediatrDemo.Logic.UseCases.Hotels.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Interfaces.Repositories
{
    public interface IHotelBookingRepository
    {
        Task<int> CreateAsync(CreateHotelBookingCommand request);
        Task<List<CreateHotelBookingCommand>> GetByIdAsync(int orderId);
    }
}
