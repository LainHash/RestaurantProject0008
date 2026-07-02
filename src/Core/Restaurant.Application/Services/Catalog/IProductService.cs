using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Services.Catalog
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<ProductResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
