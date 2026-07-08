using Restaurant.Application.Features.Catalog.Ingredients.Commands.Create;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Update;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById;
using Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update;
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
            CreateAsync(CreateIngredientSpecification specification, CancellationToken cancellationToken);

        Task<Result<IEnumerable<IngredientResponse>>>
            CreateManyAsync(CreateManyIngredientsSpecification specification, CancellationToken cancellationToken);

        Task<Result<IngredientResponse>>
            UpdateAsync(UpdateIngredientSpecification specification, CancellationToken cancellationToken);

        Task<Result<IngredientResponse>>
            UpdateStockAsync(UpdateIngredientStockSpecification specification, CancellationToken cancellationToken);

        Task<Result<object>>
            DeleteAsync(Guid id,  CancellationToken cancellationToken);

        Task<Result<object>>
            RestoreAsync(Guid id, CancellationToken cancellationToken);
    }
}
