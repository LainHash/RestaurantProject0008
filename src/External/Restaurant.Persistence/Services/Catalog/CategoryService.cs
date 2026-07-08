using Restaurant.Application.Features.Catalog.Categories.Queries.GetAll;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Application.Services.Persistence;
using Restaurant.Contract.DTOs.Catalog.Categories;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Repositories.Catalog;
using System.Net;

namespace Restaurant.Persistence.Services.Catalog
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<CategoryResponse>>>
            GetAllAsync(GetAllCategoriesSpecification specification, CancellationToken cancellationToken = default)
        {
            var totalItems = await _categoryRepository.CountAsync(specification, cancellationToken);
            var indexPage = (specification.Skip / specification.Take) + 1;

            var categories = await _categoryRepository.ToListAsync(specification, cancellationToken);

            var response = categories.Select(c => new CategoryResponse(c));
            return Result<IEnumerable<CategoryResponse>>
                .Succeed(response, Success.Retrieved, totalItems, indexPage, specification.Take);
        }

        public async Task<Result<CategoryResponse>>
            GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindAsync(id, cancellationToken);
            if (category == null)
            {
                return Result<CategoryResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new CategoryResponse(category);
            return Result<CategoryResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<CategoryResponse>> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var category = new Category(request.Name, request.Description, request.Type);
            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new CategoryResponse(category);
            return Result<CategoryResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<CategoryResponse>> UpdateAsync(Guid id, UpdateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindAsync(id);
            if (category == null)
            {
                return Result<CategoryResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            category.Update(request.Name, request.Description, request.Type);
            await _categoryRepository.UpdateAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new CategoryResponse(category);
            return Result<CategoryResponse>
                .Succeed(response, Success.Updated);
        }

        public async Task<Result<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindAsync(id);
            if (category == null)
            {
                return Result<object>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            if (category.IsDeleted)
            {
                return Result<object>
                    .Fail(Error.Deleted, HttpStatusCode.Conflict);
            }

            category.SoftDelete();

            await _categoryRepository.UpdateAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<object>
                .Succeed(null, Success.Deleted);
        }

        public async Task<Result<object>> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindAsync(id);
            if (category == null)
            {
                return Result<object>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            if (!category.IsDeleted)
            {
                return Result<object>
                    .Fail(Error.Restored, HttpStatusCode.Conflict);
            }

            category.Restore();

            await _categoryRepository.UpdateAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<object>
                .Succeed(null, Success.Restored);
        }
    }
}
