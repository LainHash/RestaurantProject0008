using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Informations.Catalog.Products;

namespace Restaurant.Domain.Entities.Catalog
{
    public partial class Product : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public bool IsMadeToOrder { get; private set; }
        public bool IsAvailable { get; private set; }

        public Guid CategoryId { get; private set; }

        public virtual Category Category { get; private set; } = null!;
        public virtual ProductStock ProductStock { get; private set; } = null!;
        public virtual ICollection<ProductImage> ProductImages { get; private set; } = [];
        public virtual ICollection<Recipe> Recipes { get; private set; } = [];

    }

    public partial class Product
    {
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

        public void Update(UpdateProductInformation information)
        {
            Name = information.Name;
            IsMadeToOrder = information.IsMadeToOrder;
            IsAvailable = information.IsAvailable;
            CategoryId = information.CategoryId;
            Description = information.Description;
        }

        public static Product Create(CreateProductInformation information)
        {
            var product = new Product(information.Name, information.IsMadeToOrder, information.IsAvailable, information.CategoryId, information.Description)
            {
                ProductStock = ProductStock.Create(information.ProductStock.UnitPrice, information.ProductStock.Unit, information.ProductStock.StockQuantity)
            };
            return product;
        }
    }
}
