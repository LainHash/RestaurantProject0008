using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Create;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.API.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllIngredientsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetIngredientByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateIngredientCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
