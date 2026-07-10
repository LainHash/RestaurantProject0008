using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.WishlistItems
{
    public class WishlistItemResponse
    {
        public DateTime AddedAt { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public WishlistItemResponse(WishlistItem wishlistItem)
        {
            AddedAt = wishlistItem.AddedAt;
            ProductName = wishlistItem.Product.Name;
        }
    }
}
