using MediatR;
using MediatrDemo.Logic.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.UseCases.Orders.Queries
{
    public record GetAllOrdersQuery : IRequest<List<string>>
    {
    }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<string>>
    {
        private readonly IOrderRepository repository;

        public GetAllOrdersQueryHandler(
            IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<string>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync();

            return result;
        }
    }
}
