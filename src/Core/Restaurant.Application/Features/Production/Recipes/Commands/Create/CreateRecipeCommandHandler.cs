using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Commands.Create
{
    internal class CreateRecipeCommandHandler
        : IRequestHandler<CreateRecipeCommand, Result<RecipeResponse>>
    {
        private readonly IRecipeService _recipeService;

        public CreateRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Result<RecipeResponse>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateRecipeSpecification(request);
            var response = await _recipeService.CreateAsync(specification, cancellationToken);
            return response;
        }
    }
}
