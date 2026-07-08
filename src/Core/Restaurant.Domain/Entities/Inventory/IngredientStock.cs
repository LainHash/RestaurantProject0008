using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Inventory
{
    public partial class IngredientStock : Entity
    {
        public decimal UnitPrice { get; private set; }
        public string Unit { get; private set; } = string.Empty;
        public decimal StockQuantity { get; private set; }
        public Guid IngredientId { get; private set; }

        public virtual Ingredient Ingredient { get; private set; } = null!;
    }

    public partial class IngredientStock
    {
        public IngredientStock(decimal unitPrice, string unit, decimal stockQuantity)
        {
            UnitPrice = unitPrice;
            Unit = unit;
            StockQuantity = stockQuantity;
        }

        public void Update(decimal unitPrice, string unit, decimal stockQuantity)
        {
            UnitPrice = unitPrice;
            Unit = unit;
            StockQuantity = stockQuantity;
        }
    }
}
