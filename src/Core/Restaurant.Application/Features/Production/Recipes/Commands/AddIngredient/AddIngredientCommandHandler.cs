using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Commands.AddIngredient
{
    internal class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, Result<RecipeResponse>>
    {
        private readonly IRecipeService _recipeService;

        public AddIngredientCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Result<RecipeResponse>> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddIngredientSpecification(request);
            var response = await _recipeService.AddIngredientAsync(specification, cancellationToken);
            return response;
        }
    }
}
