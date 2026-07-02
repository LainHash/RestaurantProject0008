using Restaurant.Application.Models;
using Restaurant.Contract.DTOs.Catalog.Categories;

namespace Restaurant.Application.Services.Catalog
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryResponse>>> 
            GetAllAsync(CancellationToken cancellationToken = default);

        Task<Result<CategoryResponse>> 
            GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<CategoryResponse>>
            CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default);

        Task<Result<CategoryResponse>>
            UpdateAsync(Guid id, UpdateCategoryRequest request, CancellationToken cancellationToken = default);

        Task<Result<object>>
            DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<object>>
            RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
