using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Production.Discounts.Queries.GetAll;
using Restaurant.Application.Features.Production.Discounts.Queries.GetById;

namespace Restaurant.API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDiscountsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetDiscountByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
