using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Commands.AddItem
{
    public class AddCartItemSpecification
        : BaseSpecification<Cart>
    {
        public Guid ProductId { get; set; }
        public AddCartItemSpecification(AddCartItemCommand command)
        {
            Criteria = c => c.Id == command.CartId;
            ProductId = command.ProductId;

            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                            .ThenInclude((CartItem ci) => ci.Product)
                                            .ThenInclude((Product p) => p.ProductStock));
        }
    }
}
