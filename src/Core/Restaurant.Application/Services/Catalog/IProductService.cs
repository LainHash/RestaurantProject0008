using Restaurant.Application.Features.Catalog.Products.Commands.Create;
using Restaurant.Application.Features.Catalog.Products.Commands.Update;
using Restaurant.Application.Features.Catalog.Products.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Products.Queries.GetById;
using Restaurant.Application.Features.Inventory.ProductStocks.Commands.Update;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Services.Catalog
{
    public interface IProductService
    {
        Task<PageResult<IEnumerable<ProductResponse>>> 
            GetAllAsync(GetAllProductsSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ProductResponse>> 
            GetByIdAsync(GetProductByIdSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ProductResponse>>
            CreateAsync(CreateProductSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ProductResponse>>
            UpdateAsync(UpdateProductSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ProductResponse>>
            UpdateAsync(UpdateProductStockSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<object>>
            DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<object>>
            RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
