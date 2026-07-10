using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Commands.CreateForGuest
{
    public class CreateCartForGuestSpecification : BaseSpecification<Cart>
    {
        public Guid SessionId { get; set; }
        public CreateCartForGuestSpecification(CreateCartForGuestCommand command)
        {
            SessionId = command.SessionId;

            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                            .ThenInclude(ci => ci.Product));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
