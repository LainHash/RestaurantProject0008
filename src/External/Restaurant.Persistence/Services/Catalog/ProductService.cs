using Restaurant.Application.Features.Catalog.Products.Queries.GetAll;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Domain.Repositories.Catalog;
using System.Net;

namespace Restaurant.Persistence.Services.Catalog
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<ProductResponse>>>
            GetAllAsync(GetAllProductSpecification specification, CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.ToListAsync(specification, cancellationToken);

            var response = products.Select(p => new ProductResponse(p));
            return Result<IEnumerable<ProductResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ProductResponse>>
            GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindAsync(id, cancellationToken);
            if (product == null)
            {
                return Result<ProductResponse>.Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new ProductResponse(product);
            return Result<ProductResponse>.Succeed(response, Success.Retrieved);
        }
    }
}
