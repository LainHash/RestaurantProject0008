using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Catalog
{
    public class Ingredient : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
