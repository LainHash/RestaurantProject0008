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

            AddInclude(x => x.User);
            AddInclude(x => x.Profile!);
        }
    }
}
