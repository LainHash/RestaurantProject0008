using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Features.Catalog.Products.Queries.GetAll
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<ProductResponse>>>
    { 
        private readonly IProductService _productService;
        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await _productService.GetAllAsync(cancellationToken);
            return response;
        }
    }
}
