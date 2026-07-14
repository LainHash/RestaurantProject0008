using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Authorization;
using Restaurant.Application.Features.Production.Recipes.Commands.AddIngredient;
using Restaurant.Application.Features.Production.Recipes.Commands.AddStep;
using Restaurant.Application.Features.Production.Recipes.Commands.Create;
using Restaurant.Application.Features.Production.Recipes.Queries.GetAll;
using Restaurant.Application.Features.Production.Recipes.Queries.GetById;
using Restaurant.Contract.DTOs.Production.RecipeIngredients;
using Restaurant.Contract.DTOs.Production.Recipes;
using Restaurant.Contract.DTOs.Production.RecipeSteps;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Restaurant.API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.AdminOrManager)]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = Roles.AdminManagerOrStaff)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRecipesQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = Roles.AdminManagerOrStaff)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetRecipeByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateRecipeCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/add-ingredients")]
        public async Task<IActionResult>
            AddIngredient([FromRoute] Guid id, [FromBody] IEnumerable<AddIngredientRequest> request, CancellationToken cancellationToken)
        {
            var command = new AddIngredientCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/add-steps")]
        public async Task<IActionResult>
            AddStep([FromRoute] Guid id, [FromBody] IEnumerable<AddStepRequest> request, CancellationToken cancellationToken)
        {
            var command = new AddStepCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
