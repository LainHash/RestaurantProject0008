using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Catalog.Products
{
    public class ProductResponse
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsMadeToOrder { get; set; }
        public bool IsAvailable { get; set; }

        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal StockQuantity { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public ProductResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            IsMadeToOrder = product.IsMadeToOrder;
            IsAvailable = product.IsAvailable;
            UnitPrice = product.ProductStock.UnitPrice;
            Unit = product.ProductStock.Unit;
            StockQuantity = product.ProductStock.StockQuantity;
            CategoryName = product.Category.Name;
        }
    }
}
