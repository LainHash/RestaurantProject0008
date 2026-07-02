using Restaurant.Application.Models;
using Restaurant.Contract.DTOs.Catalog.Categories;

namespace Restaurant.Application.Services.Catalog
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
        Task<Result<CategoryResponse>> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
