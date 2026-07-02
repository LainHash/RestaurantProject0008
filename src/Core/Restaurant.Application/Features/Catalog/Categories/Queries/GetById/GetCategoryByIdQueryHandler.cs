using MediatR;
using Restaurant.Application.Models;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Categories;

namespace Restaurant.Application.Features.Catalog.Categories.Queries.GetById
{
    internal class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;
        public GetCategoryByIdQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetByIdAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
