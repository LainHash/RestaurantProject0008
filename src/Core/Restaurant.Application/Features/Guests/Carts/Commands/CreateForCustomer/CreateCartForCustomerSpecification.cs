using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Commands.CreateForCustomer
{
    public class CreateCartForCustomerSpecification : BaseSpecification<Cart>
    {
        public CreateCartForCustomerRequest Body { get; set; }
        public CreateCartForCustomerSpecification(CreateCartForCustomerCommand command)
        {
            Body = command.Body;

            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                            .ThenInclude(ci => ci.Product));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
