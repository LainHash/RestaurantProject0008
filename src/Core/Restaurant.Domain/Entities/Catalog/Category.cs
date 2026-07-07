using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Catalog
{
    public partial class Category : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public virtual ICollection<Product> Products { get; private set; } = [];
        public virtual ICollection<Ingredient> Ingredients { get; private set; } = [];
    }

    public partial class Category
    {
        public Category(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }
        public Category(Guid id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public void Update(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }
    }
}
