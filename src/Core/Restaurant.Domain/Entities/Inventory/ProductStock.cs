using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Informations.Inventory.ProductStocks;

namespace Restaurant.Domain.Entities.Inventory
{
    public partial class ProductStock : Entity
    {
        public decimal UnitPrice { get; private set; }
        public string Unit { get; private set; } = string.Empty;
        public decimal StockQuantity { get; private set; }
        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; } = null!;
    }

    public partial class ProductStock
    {
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

        public void Update(UpdateProductStockInformation information)
        {
            UnitPrice = information.UnitPrice;
            Unit = information.Unit;
            StockQuantity = information.StockQuantity;
        }

        public static ProductStock Create(decimal unitPrice, string unit, decimal stockQuantity)
        {
            return new ProductStock(unitPrice, unit, stockQuantity);
        }

    }
}
