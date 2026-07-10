using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Wishlists.Queries.GetById
{
    public class GetWishlistByIdSpecification : BaseSpecification<Wishlist>
    {
        public GetWishlistByIdSpecification(GetWishlistByIdQuery query)
        {
            Criteria = w => w.Id == query.Id;

            AddIncludeAggregator(x => x.Include(c => c.WishlistItems)
                                            .ThenInclude(ci => ci.Product));
        }
    }
}
