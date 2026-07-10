using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.CartItems
{
    public class CartItemResponse
    {
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }

        public CartItemResponse(CartItem cartItem)
        {
            Quantity = cartItem.Quantity;
            AddedAt = cartItem.AddedAt;
            ProductName = cartItem.Product.Name;
            UnitPrice = cartItem.UnitPrice;
        }
    }
}
