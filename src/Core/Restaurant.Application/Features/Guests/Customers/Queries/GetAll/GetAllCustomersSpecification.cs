using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetAll
{
    public class GetAllCustomersSpecification
        : BaseSpecification<Customer>
    {
        public GetAllCustomersSpecification(GetAllCustomersQuery query)
        {
            AddIncludeAggregator(x => x.Include(c => c.User)
                                        .ThenInclude(u => u.Role));
            AddInclude(x => x.Profile!);
        }
    }
}
