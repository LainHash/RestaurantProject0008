using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Guests
{
    public class WishlistItem : AuditableEntity
    {
        public DateTime AddedAt { get; private set; }

        public Guid WishlistId { get; private set; }
        public Guid ProductId { get; private set; }

        public virtual Wishlist Wishlist { get; private set; } = null!;
        public virtual Product Product { get; private set; } = null!;

        public WishlistItem(Guid productId)
        {
            ProductId = productId;
            AddedAt = DateTime.UtcNow;
        }
    }
}
