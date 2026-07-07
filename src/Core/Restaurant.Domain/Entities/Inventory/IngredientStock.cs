using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Inventory
{
    public class IngredientStock : Entity
    {
        public decimal UnitPrice { get; private set; }
        public string Unit { get; private set; } = string.Empty;
        public decimal StockQuantity { get; private set; }
        public Guid IngredientId { get; private set; }

        public virtual Ingredient Ingredient { get; private set; } = null!;
    }
}
