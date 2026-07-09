using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Guests.Carts.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Carts.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Carts.Queries.GetAll;
using Restaurant.Application.Features.Guests.Carts.Queries.GetById;
using Restaurant.Contract.DTOs.Guests.Carts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Restaurant.API.Controllers.Guests
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCartsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCartByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("for-customer")]
        public async Task<IActionResult> CreateForCustomer(
            [FromBody] CreateCartForCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateCartForCustomerCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("for-guest")]
        public async Task<IActionResult> CreateForGuest(
            [FromBody] CreateCartForGuestRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateCartForGuestCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
