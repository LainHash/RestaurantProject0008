using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Guest
{
    internal class CartRepository : ICartRepository
    {
        private readonly RestaurantDbContext _context;

        public CartRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Carts.ToListAsync(cancellationToken);
        }

        public async Task<Cart?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task AddAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Carts.Add(cart);
            return Task.CompletedTask;
        }
    }
}
