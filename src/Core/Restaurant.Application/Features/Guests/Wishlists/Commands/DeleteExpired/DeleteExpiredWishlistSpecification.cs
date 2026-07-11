using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.DeleteExpired
{
    public class DeleteExpiredWishlistSpecification
        : BaseSpecification<Wishlist>
    {
        public DeleteExpiredWishlistSpecification(DeleteExpiredWishlistCommand command) 
        {
            var thresold = DateTime.UtcNow.AddDays(-3);
            Criteria = w => w.CreatedAt < thresold && !w.CustomerId.HasValue;
        }
    }
}
