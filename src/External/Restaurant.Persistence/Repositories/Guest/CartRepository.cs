using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

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

        public async Task<IEnumerable<Cart>> ToListAsync(ISpecification<Cart> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Carts.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Cart?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Cart?> FindAsync(ISpecification<Cart> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Carts.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Carts.Add(cart);
            return Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _context.Carts
                    .Where(x => x.Id == id)
                    .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        { 
            await _context.Carts
                .Where(x => ids.Contains(x.Id))
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
