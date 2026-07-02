using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Restore
{
    internal class RestoreCategoryCommandHandler : IRequestHandler<RestoreCategoryCommand, Result<object>>
    {
        private readonly ICategoryService _categoryService;
        public RestoreCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<object>> Handle(RestoreCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
