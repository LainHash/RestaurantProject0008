using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer
{
    public class CreateWishlistForCustomerSpecification : BaseSpecification<Wishlist>
    {
        public Guid UserId { get; set; }
        public CreateWishlistForCustomerSpecification(CreateWishlistForCustomerCommand command)
        {
            UserId = command.UserId;

            AddIncludeAggregator(x => x.Include(c => c.WishlistItems)
                                            .ThenInclude(ci => ci.Product));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
