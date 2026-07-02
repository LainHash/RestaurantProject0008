using Restaurant.Application.Models;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Categories;
using Restaurant.Domain.Repositories.Catalog;
using System.Net;

namespace Restaurant.Persistence.Services.Catalog
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _categoryRepository.ToListAsync(cancellationToken);

            var response = categories.Select(c => new CategoryResponse(c));
            return Result<IEnumerable<CategoryResponse>>.Succeed(response, Success.Retrieved);
        }

        public async Task<Result<CategoryResponse>> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindAsync(id, cancellationToken);
            if (category == null)
            {
                return Result<CategoryResponse>.Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new CategoryResponse(category);
            return Result<CategoryResponse>.Succeed(response, Success.Retrieved);
        }
    }
}
