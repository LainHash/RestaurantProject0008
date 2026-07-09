using Restaurant.Application.Features.Production.Recipes.Commands.AddIngredient;
using Restaurant.Application.Features.Production.Recipes.Commands.AddStep;
using Restaurant.Application.Features.Production.Recipes.Commands.Create;
using Restaurant.Application.Features.Production.Recipes.Queries.GetAll;
using Restaurant.Application.Features.Production.Recipes.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Services.Production
{
    public interface IRecipeService
    {
        Task<PageResult<IEnumerable<RecipeResponse>>> 
            GetAllAsync(GetAllRecipesSpecification specification, CancellationToken cancellationToken);

        Task<Result<RecipeResponse>> 
            GetByIdAsync(GetRecipeByIdSpecification specification, CancellationToken cancellationToken);

        Task<Result<RecipeResponse>>
            CreateAsync(CreateRecipeSpecification specification, CancellationToken cancellationToken);

        Task<Result<RecipeResponse>>
            AddIngredientAsync(AddIngredientSpecification specification, CancellationToken cancellationToken);

        Task<Result<RecipeResponse>>
            AddStepAsync(AddStepSpecification specification, CancellationToken cancellationToken);
    }
}
