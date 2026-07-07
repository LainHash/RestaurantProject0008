using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Catalog
{
    public class Ingredient : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public Guid CategoryId { get; private set; }

        public virtual Category Category { get; private set; } = null!;
        public virtual IngredientStock IngredientStock { get; private set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; } = [];
    }
}
