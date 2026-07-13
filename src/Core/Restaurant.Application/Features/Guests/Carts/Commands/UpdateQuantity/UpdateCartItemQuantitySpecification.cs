using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Commands.UpdateQuantity
{
    public class UpdateCartItemQuantitySpecification
        : BaseSpecification<Cart>
    {
        public UpdateCartItemQuantityRequest Body { get; set; }
        public UpdateCartItemQuantitySpecification(UpdateCartItemQuantityCommand command)
        {
            Criteria = c => c.Id == command.Id;
            Body = command.Body;

            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                            .ThenInclude((CartItem ci) => ci.Product)
                                            .ThenInclude((Product p) => p.ProductStock));
        }
    }
}
