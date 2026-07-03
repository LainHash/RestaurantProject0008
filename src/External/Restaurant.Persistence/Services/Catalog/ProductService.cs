using Restaurant.Application.Features.Catalog.Products.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Products.Queries.GetById;
using Restaurant.Application.Mapping.Catalog;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Repositories.Catalog;
using System.Net;

namespace Restaurant.Persistence.Services.Catalog
{
    internal class ProductService : IProductService
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
            GetByIdAsync(GetProductByIdSpecification specification, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindAsync(specification, cancellationToken);
            if (product is null)
            {
                return Result<ProductResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new ProductResponse(product);
            return Result<ProductResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ProductResponse>> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var product = Product.Create(request.ToInfo());
            await _productRepository.AddAsync(product, cancellationToken);

            var response = new ProductResponse(product);
            return Result<ProductResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<ProductResponse>> UpdateAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindAsync(id, cancellationToken);
            if (product is null)
            {
                return Result<ProductResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            product.Update(request.ToInfo());
            await _productRepository.UpdateAsync(product, cancellationToken);

            var response = new ProductResponse(product);
            return Result<ProductResponse>
                .Succeed(response, Success.Updated);
        }

        public async Task<Result<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindAsync(id, cancellationToken);
            if (product is null)
            {
                return Result<object>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            if(product.IsDeleted)
            {
                return Result<object>
                    .Fail(Error.Deleted, HttpStatusCode.Conflict);
            }

            product.SoftDelete();
            await _productRepository.UpdateAsync(product, cancellationToken);

            return Result<object>
                .Succeed(default, Success.Deleted);
        }

        public async Task<Result<object>> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindAsync(id, cancellationToken);
            if (product is null)
            {
                return Result<object>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            if(!product.IsDeleted)
            {
                return Result<object>
                    .Fail(Error.Restored, HttpStatusCode.Conflict);
            }

            product.Restore();
            await _productRepository.UpdateAsync(product, cancellationToken);

            return Result<object>
                .Succeed(default, Success.Restored);
        }
    }
}
