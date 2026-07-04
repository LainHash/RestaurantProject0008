using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Repositories.Territory;
using Restaurant.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Persistence.Repositories.Territory
{
    internal class AreaRepository : IAreaRepository
    {
        private readonly RestaurantDbContext _context;
        public AreaRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Area>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Areas.ToListAsync(cancellationToken);
        }

        public async Task<Area?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Areas.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
    }
}
