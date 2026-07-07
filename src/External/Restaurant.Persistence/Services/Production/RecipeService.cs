using Restaurant.Application.Features.Production.Recipes.Queries.GetAll;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Recipes;
using Restaurant.Domain.Repositories.Production;
using System.Net;

namespace Restaurant.Persistence.Services.Production
{
    internal class RecipeService : IRecipeService
    {
        private readonly IRecipeRespository _recipeRespository;
        public RecipeService(IRecipeRespository recipeRespository)
        {
            _recipeRespository = recipeRespository;
        }

        public async Task<Result<IEnumerable<RecipeResponse>>>
            GetAllAsync(GetAllRecipesSpecification specification, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRespository.ToListAsync(specification, cancellationToken);

            var response = recipe.Select(r => new RecipeResponse(r));
            return Result<IEnumerable<RecipeResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RecipeResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRespository.FindAsync(id, cancellationToken);
            if (recipe is null)
            {
                return Result<RecipeResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new RecipeResponse(recipe);
            return Result<RecipeResponse>
                .Succeed(response, Success.Retrieved);
        }
    }
}
