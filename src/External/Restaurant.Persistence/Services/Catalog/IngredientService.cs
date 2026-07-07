using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Domain.Repositories.Catalog;
using System.Net;

namespace Restaurant.Persistence.Services.Catalog
{
    internal class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Result<IEnumerable<IngredientResponse>>>
            GetAllAsync(GetAllIngredientsSpecification specification, CancellationToken cancellationToken)
        {
            var ingredients = await _ingredientRepository.ToListAsync(specification, cancellationToken);

            var response = ingredients.Select(i => new IngredientResponse(i));
            return Result<IEnumerable<IngredientResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<IngredientResponse>> GetByIdAsync(GetIngredientByIdSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success.Retrieved);
        }

        public Task<Result<IngredientResponse>> CreateAsync(CreateIngredientRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
