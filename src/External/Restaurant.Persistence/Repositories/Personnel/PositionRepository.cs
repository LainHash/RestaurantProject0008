using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Repositories.Personnel;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Personnel
{
    internal class PositionRepository : IPositionRepository
    {
        private readonly RestaurantDbContext _context;

        public PositionRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Positions.ToListAsync(cancellationToken);
        }

        public async Task<Position?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Positions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task AddAsync(Position position, CancellationToken cancellationToken = default)
        {
            _context.Positions.Add(position);
            return Task.CompletedTask;
        }
    }
}
