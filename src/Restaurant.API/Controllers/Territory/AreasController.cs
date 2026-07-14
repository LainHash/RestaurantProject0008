using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Authorization;
using Restaurant.Application.Features.Territory.Areas.Queries.GetAll;
using Restaurant.Application.Features.Territory.Areas.Queries.GetById;

namespace Restaurant.API.Controllers.Territory
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.AdminOrManager)]
    public class AreasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AreasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAreasQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetAreaByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
