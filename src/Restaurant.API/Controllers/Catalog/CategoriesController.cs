using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Authorization;
using Restaurant.Application.Features.Catalog.Categories.Commands.Create;
using Restaurant.Application.Features.Catalog.Categories.Commands.Delete;
using Restaurant.Application.Features.Catalog.Categories.Commands.Restore;
using Restaurant.Application.Features.Catalog.Categories.Commands.Update;
using Restaurant.Application.Features.Catalog.Categories.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Categories.Queries.GetById;
using Restaurant.Contract.DTOs.Catalog.Categories;

namespace Restaurant.API.Controllers.Catalog
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.AdminOrManager)] // mặc định toàn controller; GET sẽ override bằng [AllowAnonymous]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateCategoryCommand(request), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id, request), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> Restore([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RestoreCategoryCommand(id), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
