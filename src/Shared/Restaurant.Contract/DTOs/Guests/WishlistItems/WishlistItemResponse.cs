using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.WishlistItems
{
    public class WishlistItemResponse
    {
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime AddedAt { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public WishlistItemResponse(WishlistItem wishlistItem)
        {
            Quantity = wishlistItem.Quantity;
            LineTotal = wishlistItem.LineTotal;
            AddedAt = wishlistItem.AddedAt;
            ProductName = wishlistItem.Product.Name;
        }
    }
}
