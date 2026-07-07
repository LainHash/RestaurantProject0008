using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Production
{
    public class Recipe : SoftDeletableEntity
    {
        public string Inspiration { get; private set; } = string.Empty;
        public string Note { get; private set; } = string.Empty;
        // Foreign Keys
        public Guid ProductId { get; private set; }

        // Navigation Properties
        public virtual Product Product { get; private set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; } = [];
    }
}
