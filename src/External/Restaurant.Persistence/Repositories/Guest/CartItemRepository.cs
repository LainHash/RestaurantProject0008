using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Guest
{
    internal class CartItemRepository : ICartItemRepository
    {
        private readonly RestaurantDbContext _context;

        public CartItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            _context.CartItems.Add(cartItem);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            _context.CartItems.Update(cartItem);
            return Task.CompletedTask;
        }
    }
}
