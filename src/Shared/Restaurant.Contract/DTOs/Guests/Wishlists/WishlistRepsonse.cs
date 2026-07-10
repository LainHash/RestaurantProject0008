using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Contract.DTOs.Guests.WishlistItems;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.Wishlists
{
    public class WishlistRepsonse
    {
        public Guid Id { get; set; }

        public Guid? SessionId { get; set; }
        public Guid? CustomerId { get; set; }

        public IEnumerable<WishlistItemResponse> WishlistItems { get; set; } = [];

        public WishlistRepsonse(Wishlist wishlist)
        {
            Id = wishlist.Id;
            SessionId = wishlist.SessionId;
            CustomerId = wishlist.CustomerId;
            WishlistItems = wishlist.WishlistItems.Select(x => new WishlistItemResponse(x));
        }
    }
}
