using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Repositories.Territory;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

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

        public async Task<IEnumerable<Area>> GetAllAsync(ISpecification<Area> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Areas.AsQueryable(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Area?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Areas.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<Area?> FindAsync(ISpecification<Area> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Areas.AsQueryable(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
