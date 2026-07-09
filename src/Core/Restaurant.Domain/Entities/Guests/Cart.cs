using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Guests
{
    public partial class Cart : AuditableEntity
    {
        public Guid? SessionId { get; private set; }
        public Guid? CustomerId { get; private set; }

        public virtual Customer? Customer { get; private set; }
        public virtual ICollection<CartItem> CartItems { get; private set; } = [];
    }

    public partial class Cart
    {
        public void SetCustomerId(Guid id)
        {
            CustomerId = id;
        }

        public void SetGuestId(Guid id)
        {
            SessionId = id;
        }
    }
}
