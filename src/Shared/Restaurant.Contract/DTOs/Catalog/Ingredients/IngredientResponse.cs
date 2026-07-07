using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Catalog.Ingredients
{
    public class IngredientResponse
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public IngredientResponse(Ingredient ingredient)
        {
            Name = ingredient.Name;
            Description = ingredient.Description;
            CategoryName = ingredient.Category.Name;
        }
    }
}
