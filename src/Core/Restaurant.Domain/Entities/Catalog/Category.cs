using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Catalog
{
    public partial class Category : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string Type { get; private set; } = string.Empty;

        public virtual ICollection<Product> Products { get; private set; } = [];
        public virtual ICollection<Ingredient> Ingredients { get; private set; } = [];
    }

    public partial class Category
    {
        public Category(string name, string? description, string type)
        {
            Name = name;
            Description = description;
            Type = type;
        }
        public Category(Guid id, string name, string? description, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        public void Update(string name, string? description, string type)
        {
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
