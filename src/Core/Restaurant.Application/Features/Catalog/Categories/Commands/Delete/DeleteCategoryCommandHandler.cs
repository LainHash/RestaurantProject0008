using MediatR;
using Restaurant.Application.Models;
using Restaurant.Application.Services.Catalog;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Delete
{
    internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<object>>
    {
        private readonly ICategoryService _categoryService;
        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Result<object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
