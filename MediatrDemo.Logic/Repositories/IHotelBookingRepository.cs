using MediatrDemo.Logic.Commands.Hotels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Repositories
{
    public interface IHotelBookingRepository
    {
        Task<int> CreateAsync(CreateHotelBookingCommand request);
        Task<List<CreateHotelBookingCommand>> GetByIdAsync(int orderId);
    }
}
