using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Repositories.Territory;
using Restaurant.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Persistence.Repositories.Territory
{
    internal class RestaurantTableRepository : IRestaurantTableRepository
    {
        private readonly RestaurantDbContext _context;
        public RestaurantTableRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestaurantTable>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.RestaurantTables.ToListAsync(cancellationToken);
        }

        public async Task<RestaurantTable?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.RestaurantTables.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task AddAsync(RestaurantTable table, CancellationToken cancellationToken = default)
        {
            _context.RestaurantTables.Add(table);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(RestaurantTable table, CancellationToken cancellationToken = default)
        {
            _context.RestaurantTables.Update(table);
            return Task.CompletedTask;
        }
    }
}
