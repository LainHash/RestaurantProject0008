using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Production
{
    public class Recipe : SoftDeletableEntity
    {
        public string Inspiration { get; set; } = null!;

        // Foreign Keys
        public int ProductId { get; set; }

        // Navigation Properties
        public virtual Product Product { get; set; } = null!;
        public virtual IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}
