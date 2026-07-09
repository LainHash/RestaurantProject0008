using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.Carts
{
    public class CartResponse
    {
        public Guid Id { get; set; }

        public Guid? SessionId { get; set; }
        public Guid? CustomerId { get; set; }

        public IEnumerable<CartItemResponse> CartItems { get; set; } = [];

        public CartResponse(Cart cart)
        {
            Id = cart.Id;
            SessionId = cart.SessionId;
            CustomerId = cart.CustomerId;
            CartItems = cart.CartItems.Select(x => new CartItemResponse(x));
        }
    }
}
