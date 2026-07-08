using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Restore
{
    internal class RestoreIngredientCommandHandler : IRequestHandler<RestoreIngredientCommand, Result<object>>
    {
        private readonly IIngredientService _ingredientService;

        public RestoreIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<object>> Handle(RestoreIngredientCommand request, CancellationToken cancellationToken)
        {
            var response = await _ingredientService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
