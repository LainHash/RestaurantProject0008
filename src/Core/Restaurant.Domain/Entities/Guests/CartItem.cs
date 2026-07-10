using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Guests
{
    public partial class CartItem : AuditableEntity
    {
        public int Quantity { get; private set; }
        public decimal LineTotal { get; private set; }
        public DateTime AddedAt { get; private set; }

        public Guid CartId { get; private set; }
        public Guid ProductId { get; private set; }

        public virtual Cart Cart { get; private set; } = null!;
        public virtual Product Product { get; private set; } = null!;
    }

    public partial class CartItem
    {
        public CartItem(Guid cartId, Guid productId)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = 1;
            LineTotal = 0;
            AddedAt = DateTime.UtcNow;
        }

        public void IncreaseQuantity(int amount = 1)
        {
            Quantity += amount;
        }

        public void SetLineTotal()
        {
            LineTotal = Quantity * Product.ProductStock.UnitPrice;
        }
    }
}
