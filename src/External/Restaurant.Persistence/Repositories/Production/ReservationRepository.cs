using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Persistence.Contexts;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant.Persistence.Repositories.Production
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantDbContext _context;
        public ReservationRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Reservations.ToListAsync(cancellationToken);
        }

        public async Task<Reservation?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
