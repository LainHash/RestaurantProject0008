using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Catalog
{
    public class Category : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = [];

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
