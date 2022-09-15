using MediatR;
using MediatrDemo.Logic.Usecases.Orders.Commands;
using MediatrDemo.Logic.Usecases.Orders.Queries;
using MediatrDemo.Logic.UseCases.Orders.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrDemo.Api.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("api/orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync(CreateOrderCommand command)
        {
            var id = await mediator.Send(command);

            return Ok(id);
        }

        [HttpGet("api/orders/{id}")]

        public async Task<ActionResult<CreateOrderCommand>> GetByIdAsync(int id)
        {
            var query = new GetOrderQuery(id);
            var result = await mediator.Send(query);
            return result;
        }

        [HttpGet("api/orders")]
        public async Task<ActionResult<List<string>>> GetAllAsync()
        {
            var query = new GetAllOrdersQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("api/orders/DeleteAll")]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await mediator.Send(new DeleteAllOrdersCommand());

            return NoContent();
        }
    }
}
