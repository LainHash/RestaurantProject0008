using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll
{
    public class GetAllWishlistsSpecification : BaseSpecification<Wishlist>
    {
        public GetAllWishlistsSpecification(GetAllWishlistsQuery query)
        {
            AddIncludeAggregator(x => x.Include(c => c.WishlistItems)
                                            .ThenInclude(ci => ci.Product));
        }
    }
}
