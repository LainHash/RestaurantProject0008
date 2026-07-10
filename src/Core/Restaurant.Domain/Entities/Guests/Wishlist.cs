using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Guests
{
    public partial class Wishlist : AuditableEntity
    {
        public Guid? SessionId { get; private set; }
        public Guid? CustomerId { get; private set; }

        public virtual Customer? Customer { get; private set; }
        public virtual ICollection<WishlistItem> WishlistItems { get; private set; } = [];
    }

    public partial class Wishlist
    {
        public void AddCustomer(Guid id)
        {
            CustomerId = id;
        }

        public void AddGuest(Guid id)
        {
            SessionId = id;
        }
    }
}
