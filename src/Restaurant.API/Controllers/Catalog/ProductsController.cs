using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Catalog.Products.Commands.Create;
using Restaurant.Application.Features.Catalog.Products.Commands.Delete;
using Restaurant.Application.Features.Catalog.Products.Commands.Restore;
using Restaurant.Application.Features.Catalog.Products.Commands.Update;
using Restaurant.Application.Features.Catalog.Products.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Products.Queries.GetById;
using Restaurant.Application.Features.Inventory.ProductStocks.Commands.Update;
using Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage;
using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Contract.DTOs.Inventory.ProductStocks;
using Restaurant.Contract.DTOs.Misc.Images;

namespace Restaurant.API.Controllers.Catalog
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateProductCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/stock")]
        public async Task<IActionResult> UpdateStock([FromRoute] Guid id, [FromBody] UpdateProductStockRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateProductStockCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> Restore([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new RestoreProductCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/images")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage(
            [FromRoute] Guid id,
            IFormFile file,
            [FromForm] UploadImageRequest metadata,
            CancellationToken cancellationToken)
        {
            if (file is null || file.Length == 0)
                return BadRequest("File ảnh không được để trống.");

            await using var stream = file.OpenReadStream();

            var command = new UploadProductImageCommand(id, stream, file.FileName, metadata);

            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
