using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer;
using Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest;
using Restaurant.Application.Features.Production.Reservations.Command.UpdateStatus;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant.API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllReservationsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("schedule/{weekStart}")]
        public async Task<IActionResult> GetAllByWeek([FromRoute] DateTime weekStart, CancellationToken cancellationToken)
        {
            var query = new GetAllReservationsByWeekQuery(weekStart);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetReservationByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateForCustomer(
            [FromBody] CreateReservationForCustomerRequest request,
            CancellationToken cancellationToken)
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

            var command = new CreateReservationForCustomerCommand(request, userId.Value);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("for-guest")]
        public async Task<IActionResult> CreateForGuest(
            [FromBody] CreateReservationForGuestRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateReservationForGuestCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/update-status")]
        public async Task<IActionResult> UpdateStatus(
            [FromRoute] Guid id,
            [FromForm] UpdateReservationStatusRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateReservationStatusCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
