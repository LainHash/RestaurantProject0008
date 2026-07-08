using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Create;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Delete;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Restore;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Update;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById;
using Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update;
using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Contract.DTOs.Inventory.IngredientStocks;

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
        public async Task<IActionResult> Create(
            [FromBody] CreateIngredientRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateIngredientCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create-many")]
        public async Task<IActionResult> CreateMany(
            [FromBody] List<CreateIngredientRequest> requests,
            CancellationToken cancellationToken)
        {
            var command = new CreateManyIngredientsCommand(requests);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateIngredientRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateIngredientCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/stock")]
        public async Task<IActionResult> UpdateStock(
            [FromRoute] Guid id,
            [FromBody] UpdateIngredientStockRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateIngredientStockCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteIngredientCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> Restore([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new RestoreIngredientCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
