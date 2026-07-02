using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Inventory
{
    public class ProductStock : Entity
    {
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal StockQuantity { get; set; }
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;


        public ProductStock(decimal unitPrice, string unit, decimal stockQuantity)
        {
            UnitPrice = unitPrice;
            Unit = unit;
            StockQuantity = stockQuantity;
        }


        public ProductStock(Guid id, decimal unitPrice, string unit, decimal stockQuantity, Guid productId)
        {
            Id = id;
            UnitPrice = unitPrice;
            Unit = unit;
            StockQuantity = stockQuantity;
            ProductId = productId;
        }
    }
}
