using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Guests
{
    public partial class CartItem : AuditableEntity
    {
        public int Quantity { get; private set; }
        public DateTime AddedAt { get; private set; }

        public Guid CartId { get; private set; }

        public Guid ProductId { get; private set; }
        //snapshot
        public decimal UnitPrice { get; private set; }

        public virtual Cart Cart { get; private set; } = null!;
        public virtual Product Product { get; private set; } = null!;
    }

    public partial class CartItem
    {
        public CartItem(Guid productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = 1;
            AddedAt = DateTime.UtcNow;
        }
        public CartItem(Guid cartId, Guid productId, decimal unitPrice)
        {
            CartId = cartId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = 1;
            AddedAt = DateTime.UtcNow;
        }

        public void IncreaseQuantity(int amount = 1)
        {
            Quantity += amount;
        }

        public void DecreaseQuantity(int amount = -1)
        {
            Quantity += amount;
        }
    }
}
