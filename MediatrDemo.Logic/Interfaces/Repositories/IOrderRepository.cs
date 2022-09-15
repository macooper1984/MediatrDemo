using MediatrDemo.Logic.Usecases.Orders.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateAsync(CreateOrderCommand request);
        Task DeleteAllAsync();
        Task<List<string>> GetAllAsync();
        Task<CreateOrderCommand> GetByIdAsync(int id);
    }
}
