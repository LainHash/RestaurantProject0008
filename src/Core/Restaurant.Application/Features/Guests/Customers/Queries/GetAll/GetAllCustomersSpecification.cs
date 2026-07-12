using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetAll
{
    public class GetAllCustomersSpecification
        : BaseSpecification<Customer>
    {
        public GetAllCustomersSpecification(GetAllCustomersQuery query)
        {
            AddInclude(x => x.User);
            AddInclude(x => x.PersonalInformation!);
        }
    }
}
