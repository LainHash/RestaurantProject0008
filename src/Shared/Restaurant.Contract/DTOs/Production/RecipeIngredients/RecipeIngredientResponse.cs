using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Production.RecipeIngredients
{
    public class RecipeIngredientResponse
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public decimal StockQuantity { get; init; }
        public decimal Quantity { get; init; }

        public RecipeIngredientResponse(Ingredient ingredient, decimal quantity)
        {
            IngredientId = ingredient.Id;
            Name = ingredient.Name;
            CategoryName = ingredient.Category.Name;
            StockQuantity = ingredient.IngredientStock.StockQuantity;
            Quantity = quantity;
        }
    }
}
