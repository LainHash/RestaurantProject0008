using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Catalog.Ingredients
{
    public class IngredientResponse
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public decimal UnitPrice { get; init; }
        public string Unit { get; init; } = string.Empty;
        public decimal StockQuantity { get; init; }

        public IngredientResponse(Ingredient ingredient)
        {
            Name = ingredient.Name;
            Description = ingredient.Description;
            CategoryName = ingredient.Category.Name;
            UnitPrice = ingredient.IngredientStock.UnitPrice;
            Unit = ingredient.IngredientStock.Unit;
            StockQuantity = ingredient.IngredientStock.StockQuantity;
        }
    }
}
