using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Commands.AddStep
{
    internal class AddStepCommandHandler
        : IRequestHandler<AddStepCommand, Result<RecipeResponse>>
    {
        private readonly IRecipeService _recipeService;

        public AddStepCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Result<RecipeResponse>> Handle(AddStepCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddStepSpecification(request);
            var response = await _recipeService.AddStepAsync(specification, cancellationToken);
            return response;
        }
    }
}
