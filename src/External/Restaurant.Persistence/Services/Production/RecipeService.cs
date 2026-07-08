using Restaurant.Application.Features.Production.Recipes.Commands.AddIngredient;
using Restaurant.Application.Features.Production.Recipes.Commands.Create;
using Restaurant.Application.Features.Production.Recipes.Queries.GetAll;
using Restaurant.Application.Features.Production.Recipes.Queries.GetById;
using Restaurant.Application.Mapping.Production;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Recipes;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using System.Net;

namespace Restaurant.Persistence.Services.Production
{
    internal class RecipeService : IRecipeService
    {
        private readonly IRecipeRespository _recipeRespository;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RecipeService(
            IRecipeRespository recipeRespository,
            IRecipeIngredientRepository recipeIngredientRepository,
            IUnitOfWork unitOfWork)
        {
            _recipeRespository = recipeRespository;
            _recipeIngredientRepository = recipeIngredientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<RecipeResponse>>>
            GetAllAsync(GetAllRecipesSpecification specification, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRespository.ToListAsync(specification, cancellationToken);

            var response = recipe.Select(r => new RecipeResponse(r));
            return Result<IEnumerable<RecipeResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RecipeResponse>> GetByIdAsync(GetRecipeByIdSpecification specification, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRespository.FindAsync(specification, cancellationToken);
            if (recipe is null)
            {
                return Result<RecipeResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new RecipeResponse(recipe);
            return Result<RecipeResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RecipeResponse>> CreateAsync(CreateRecipeSpecification specification, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(specification.Body.ToInfo());
            await _recipeRespository.AddAsync(recipe, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(recipe.Id);
            var createdRecipe = await _recipeRespository.FindAsync(specification, cancellationToken);
            var response = new RecipeResponse(createdRecipe!);
            return Result<RecipeResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RecipeResponse>> 
            AddIngredientAsync(AddIngredientSpecification specification, CancellationToken cancellationToken)
        {
            var recipeIngredients = specification.Body.IngredientIds.Select(i => new RecipeIngredient(specification.RecipeId, i));
            await _recipeIngredientRepository.AddRangeAsync(recipeIngredients, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var recipe = await _recipeRespository.FindAsync(specification, cancellationToken);

            var response = new RecipeResponse(recipe!);
            return Result<RecipeResponse>
                .Succeed(response, Success.Retrieved);
        }
    }
}
