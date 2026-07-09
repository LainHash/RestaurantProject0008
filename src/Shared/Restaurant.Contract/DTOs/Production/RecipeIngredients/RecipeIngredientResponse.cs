using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Production.RecipeIngredients
{
    public class RecipeIngredientResponse
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public decimal Quantity { get; init; }
        public string Unit {  get; set; } = string.Empty;

        public RecipeIngredientResponse(Ingredient ingredient, decimal quantity, string unit)
        {
            IngredientId = ingredient.Id;
            Name = ingredient.Name;
            CategoryName = ingredient.Category.Name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
