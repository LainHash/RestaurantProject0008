using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetById
{
    public class GetCustomerByIdSpecification
        : BaseSpecification<Customer>
    {
        public GetCustomerByIdSpecification(GetCustomerByIdQuery query)
        {
            Criteria = x => x.Id == query.Id;

            AddIncludeAggregator(x => x.Include(c => c.User)
                                        .ThenInclude(u => u.Role));
            AddInclude(x => x.Profile!);
        }
    }
}
