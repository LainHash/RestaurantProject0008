using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.AddItem
{
    public class AddWishlistItemSpecification
        : BaseSpecification<Wishlist>
    {
        public Guid ProductId { get; set; }
        public AddWishlistItemSpecification(AddWishlistItemCommand command)
        {
            Criteria = w => w.Id == command.WishlistId;

            ProductId = command.ProductId;

            AddIncludeAggregator(x => x.Include(c => c.WishlistItems)
                                            .ThenInclude(ci => ci.Product));
        }
    }
}
