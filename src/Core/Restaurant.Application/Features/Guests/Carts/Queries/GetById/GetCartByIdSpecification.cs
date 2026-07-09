using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Queries.GetById
{
    public class GetCartByIdSpecification : BaseSpecification<Cart>
    {
        public GetCartByIdSpecification(GetCartByIdQuery query)
        {
            Criteria = c => c.Id == query.Id;

            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                            .ThenInclude(ci => ci.Product));
        }
    }
}
