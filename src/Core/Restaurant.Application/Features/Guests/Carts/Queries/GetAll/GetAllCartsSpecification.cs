using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Queries.GetAll
{
    public class GetAllCartsSpecification : BaseSpecification<Cart>
    {
        public GetAllCartsSpecification(GetAllCartsQuery query)
        {
            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                            .ThenInclude(ci => ci.Product));
        }
    }
}
