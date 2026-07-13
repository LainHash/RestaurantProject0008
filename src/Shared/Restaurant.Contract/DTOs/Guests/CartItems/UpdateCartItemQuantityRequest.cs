namespace Restaurant.Contract.DTOs.Guests.CartItems
{
    public class UpdateCartItemQuantityRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
