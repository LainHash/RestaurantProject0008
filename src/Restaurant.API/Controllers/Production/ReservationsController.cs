using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Production.Reservations.Command.Create;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Application.Features.Territory.RestaurantTables.Queries.GetAll;
using Restaurant.Contract.DTOs.Production.Reservations;

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

        [HttpGet("/schedule/{weekStart}")]
        public async Task<IActionResult> GetAllByWeek([FromRoute] DateTime weekStart, CancellationToken cancellationToken)
        {
            var query = new GetAllReservationsByWeekQuery(weekStart);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetReservationByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationRequest request, CancellationToken cancellation)
        {
            var command = new CreateReservationCommand(request);
            var result = await _mediator.Send(command, cancellation);
            return StatusCode(result.StatusCode, result);
        }
    }
}
