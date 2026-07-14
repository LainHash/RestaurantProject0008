using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Authorization;
using Restaurant.Application.Features.Guests.Wishlists.Commands.AddItem;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Wishlists.Commands.DeleteExpired;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetById;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Restaurant.API.Controllers.Guests
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishlistsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = Roles.AdminOrManager)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllWishlistsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetWishlistByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = Roles.Customer)]
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

        [AllowAnonymous]
        [HttpPost("for-guest")]
        public async Task<IActionResult> CreateForGuest([FromBody] Guid sessionId, CancellationToken cancellationToken)
        {
            var command = new CreateWishlistForGuestCommand(sessionId);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/add-item")]
        public async Task<IActionResult> AddItem(
            [FromRoute] Guid id,
            [FromBody] Guid productId,
            CancellationToken cancellationToken)
        {
            var command = new AddWishlistItemCommand(id, productId);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = Roles.AdminOrManager)]
        [HttpDelete]
        public async Task<IActionResult> DeleteExpired(
            CancellationToken cancellationToken)
        {
            var command = new DeleteExpiredWishlistCommand();
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
