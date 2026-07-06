using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Production
{
    public class RecipeIngredient : Entity
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }

        // Navigation Properties
        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
