using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Production
{
    internal class DiscountRepository : IDiscountRepository
    {
        private readonly RestaurantDbContext _context;

        public DiscountRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discount>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Discounts.ToListAsync(cancellationToken);
        }

        public async Task<Discount?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Discounts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
