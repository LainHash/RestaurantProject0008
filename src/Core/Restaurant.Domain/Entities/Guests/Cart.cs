using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Guests
{
    public class Cart : AuditableEntity
    {
        public Guid? SessionId { get; private set; }
        public Guid? CustomerId { get; private set; }

        public virtual Customer? Customer { get; private set; }
        public virtual ICollection<CartItem> CartItems { get; private set; } = [];
    }
}
