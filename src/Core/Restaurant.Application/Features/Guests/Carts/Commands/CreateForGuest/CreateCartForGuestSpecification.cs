using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Domain.Entities.Catalog;
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
                                            .ThenInclude((CartItem ci) => ci.Product)
                                            .ThenInclude((Product p) => p.ProductStock));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
