using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Personnel.Positions.Commands.Create;
using Restaurant.Application.Features.Personnel.Positions.Queries.GetAll;
using Restaurant.Application.Features.Personnel.Positions.Queries.GetById;
using Restaurant.Contract.DTOs.Personnel.Positions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Restaurant.API.Controllers.Personnel
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPositionsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPositionByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePositionRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreatePositionCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
