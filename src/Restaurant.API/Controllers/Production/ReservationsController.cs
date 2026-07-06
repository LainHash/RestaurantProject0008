using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer;
using Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Contract.DTOs.Production.Reservations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<IActionResult> CreateForCustomer([FromBody] CreateReservationForCustomerRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateReservationForCustomerCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("/for-guest")]
        public async Task<IActionResult> CreateForGuest([FromBody] CreateReservationForGuestRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateReservationForGuestCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
