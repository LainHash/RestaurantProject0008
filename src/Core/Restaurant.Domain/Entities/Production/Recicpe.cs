using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Production
{
    public class Recipe : SoftDeletableEntity
    {
        public string Inspiration { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        // Foreign Keys
        public Guid ProductId { get; set; }

        // Navigation Properties
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}
