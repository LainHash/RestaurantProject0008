using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Domain.Entities.Catalog
{
    public class Product : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsMadeToOrder { get; set; }
        public bool IsAvailable { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ProductStock ProductStock { get; set; } = null!;
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public Product(string name, bool isMadeToOrder, bool isAvailable, Guid categoryId, string? description = null)
        {
            Name = name;
            IsMadeToOrder = isMadeToOrder;
            IsAvailable = isAvailable;
            CategoryId = categoryId;
            Description = description;
        }

        public Product(Guid id, string name, bool isMadeToOrder, bool isAvailable, Guid categoryId, string? description = null)
        {
            Id = id;
            Name = name;
            IsMadeToOrder = isMadeToOrder;
            IsAvailable = isAvailable;
            CategoryId = categoryId;
            Description = description;
        }

        public static Product Create(string name, string? description, bool isMadeToOrder, bool isAvailable, Guid categoryId, decimal unitPrice, string unit, decimal stockQuantity)
        {
            var product = new Product(name, isMadeToOrder, isAvailable, categoryId, description)
            {
                ProductStock = new ProductStock(unitPrice, unit, stockQuantity)
            };
            return product;
        }
    }
}
