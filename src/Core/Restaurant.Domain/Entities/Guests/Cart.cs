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
        public void AddCustomer(Guid id)
        {
            CustomerId = id;
        }

        public void AddGuest(Guid id)
        {
            SessionId = id;
        }

        public void AddItem(Guid productId, decimal unitPrice)
        {
            var item = CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item is null)
            {
                var addedCartItem = new CartItem(Id, productId, unitPrice);
                CartItems.Add(addedCartItem);
            }
            else
            {
                item.IncreaseQuantity();
            }
        }
    }
}
