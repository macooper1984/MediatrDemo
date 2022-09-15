using MediatR;
using MediatrDemo.Logic.Commands.Flights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrDemo.Api.Controllers
{
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlightBookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("api/flightbookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync(CreateFlightBookingCommand command)
        {
            var id = await mediator.Send(command);

            return Ok(id);
        }
    }
}
