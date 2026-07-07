using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Enums;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Repositories.Territory;
using Restaurant.Persistence.Contexts;

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

        public async Task<IEnumerable<RestaurantTable>> GetAvailableTablesAsync(string areaType, int minCapacity, DateTime reservationTime, TimeSpan duration, CancellationToken cancellationToken = default)
        {
            var endTime = reservationTime.Add(duration);

            return await _context.RestaurantTables
                .Include(t => t.Area)
                .Include(t => t.Reservations)
                .Where(t => t.Area.Type == areaType
                            && t.Capacity >= minCapacity
                            && t.Status == nameof(TableStatus.Available)
                            && !t.Reservations.Any(r =>
                                r.ReservationTime < endTime &&
                                r.ReservationTime.Add(duration) > reservationTime &&
                                r.Status != nameof(ReservationStatus.Cancelled) && r.Status != nameof(ReservationStatus.NoShow)))
                .OrderBy(t => t.Capacity)   // Best-Fit: ưu tiên bàn nhỏ nhất đủ chỗ
                .ToListAsync(cancellationToken);
        }
    }
}
