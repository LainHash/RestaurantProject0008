using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetById;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Restaurant.API.Controllers.Guests
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishlistsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllWishlistsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetWishlistByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateForCustomer(CancellationToken cancellationToken)
        {
            Guid? userId = null!;

            if (User.Identity?.IsAuthenticated == true)
            {
                var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                   ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                if (Guid.TryParse(userIdString, out Guid parsedId))
                {
                    userId = parsedId;
                }
            }

            var command = new CreateWishlistForCustomerCommand(userId.Value);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("for-guest")]
        public async Task<IActionResult> CreateForGuest([FromBody] Guid sessionId, CancellationToken cancellationToken)
        {
            var command = new CreateWishlistForGuestCommand(sessionId);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
