using Restaurant.Domain.Abstractions;

namespace Restaurant.Domain.Entities.Catalog
{
    public class Category : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Category(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
