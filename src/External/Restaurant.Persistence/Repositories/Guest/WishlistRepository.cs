using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

namespace Restaurant.Persistence.Repositories.Guest
{
    internal class WishlistRepository : IWishlistRepository
    {
        private readonly RestaurantDbContext _context;

        public WishlistRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wishlist>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Wishlists.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Wishlist>> ToListAsync(ISpecification<Wishlist> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Wishlists.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Wishlist?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Wishlists.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Wishlist?> FindAsync(ISpecification<Wishlist> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Wishlists.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(Wishlist wishlist, CancellationToken cancellationToken = default)
        {
            _context.Wishlists.Add(wishlist);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Wishlist wishlist, CancellationToken cancelToken = default)
        {
            _context.Wishlists.Update(wishlist);
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
