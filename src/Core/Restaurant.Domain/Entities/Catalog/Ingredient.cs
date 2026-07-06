using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Catalog
{
    public class Ingredient : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}
