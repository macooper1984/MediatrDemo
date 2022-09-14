using MediatrDemo.Logic.Commands;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateAsync(CreateOrderCommand request);
    }
}
