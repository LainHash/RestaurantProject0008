using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Guests
{
    public class CartItem : AuditableEntity
    {
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime AddedAt { get; set; }

        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
