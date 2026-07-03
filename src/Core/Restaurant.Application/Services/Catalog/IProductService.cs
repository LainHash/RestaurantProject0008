using Restaurant.Application.Features.Catalog.Products.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Products.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Services.Catalog
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductResponse>>> 
            GetAllAsync(GetAllProductSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ProductResponse>> 
            GetByIdAsync(GetProductByIdSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ProductResponse>>
            CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default);

        Task<Result<object>>
            DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<object>>
            RestoreAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
