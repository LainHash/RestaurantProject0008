using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Production
{
    public partial class RecipeIngredient : Entity
    {
        public Guid RecipeId { get; private set; }
        public Guid IngredientId { get; private set; }
        public decimal Quantity { get; private set; }
        public string Unit { get; private set; } = string.Empty;

        // Navigation Properties
        public virtual Recipe Recipe { get; private set; } = null!;
        public virtual Ingredient Ingredient { get; private set; } = null!;
    }

    public partial class RecipeIngredient
    {
        public RecipeIngredient(Guid recipeId, Guid ingredientId, decimal quantity, string unit)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
