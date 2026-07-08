using Restaurant.Contract.DTOs.Inventory.IngredientStocks;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update
{
    public class UpdateIngredientStockSpecification : BaseSpecification<Ingredient>
    {
        public UpdateIngredientStockRequest Body { get; set; }
        public UpdateIngredientStockSpecification(UpdateIngredientStockCommand command)
        {
            Criteria = i => i.Id == command.Id;
            Body = command.Body;

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }
    }
}
