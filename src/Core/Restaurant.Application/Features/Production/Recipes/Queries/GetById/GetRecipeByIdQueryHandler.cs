using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Queries.GetById
{
    internal class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, Result<RecipeResponse>>
    {
        private readonly IRecipeService _recipeService;
        public GetRecipeByIdQueryHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Result<RecipeResponse>> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _recipeService.GetByIdAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
