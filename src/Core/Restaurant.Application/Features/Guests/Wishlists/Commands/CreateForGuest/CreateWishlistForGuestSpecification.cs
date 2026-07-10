using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest
{
    public class CreateWishlistForGuestSpecification : BaseSpecification<Wishlist>
    {
        public Guid SessionId { get; set; }
        public CreateWishlistForGuestSpecification(CreateWishlistForGuestCommand command)
        {
            SessionId = command.SessionId;

            AddIncludeAggregator(x => x.Include(c => c.WishlistItems)
                                            .ThenInclude(ci => ci.Product));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
