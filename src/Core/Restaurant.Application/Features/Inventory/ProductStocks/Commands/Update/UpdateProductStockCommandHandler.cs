using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Features.Inventory.ProductStocks.Commands.Update
{
    internal class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, Result<ProductResponse>>
    {
        private readonly IProductService _productService;

        public UpdateProductStockCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<ProductResponse>> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateProductStockSpecification(request);
            var response = await _productService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}
