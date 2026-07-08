using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Contract.DTOs.Inventory.IngredientStocks;

namespace Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update
{
    public record UpdateIngredientStockCommand(Guid Id, UpdateIngredientStockRequest Body)
        : IRequest<Result<IngredientResponse>>
    {
    }
}
