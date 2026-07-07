using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Services.Catalog
{
    public interface IIngredientService
    {
        Task<Result<IEnumerable<IngredientResponse>>> 
            GetAllAsync(GetAllIngredientsSpecification specification, CancellationToken cancellationToken);

        Task<Result<IngredientResponse>> 
            GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
