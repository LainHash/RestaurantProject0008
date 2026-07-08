using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Contract.DTOs.Inventory.IngredientStocks;

namespace Restaurant.Application.Services.Catalog
{
    public interface IIngredientService
    {
        Task<Result<IEnumerable<IngredientResponse>>> 
            GetAllAsync(GetAllIngredientsSpecification specification, CancellationToken cancellationToken);

        Task<Result<IngredientResponse>> 
            GetByIdAsync(GetIngredientByIdSpecification specification, CancellationToken cancellationToken);
        
        Task<Result<IngredientResponse>>
            CreateAsync(CreateIngredientRequest request, CancellationToken cancellationToken);

        Task<Result<IngredientResponse>>
            UpdateAsync(Guid id, UpdateIngredientRequest request, CancellationToken cancellationToken);

        Task<Result<IngredientResponse>>
            UpdateStockAsync(Guid id, UpdateIngredientStockRequest request, CancellationToken cancellationToken);
    }
}
