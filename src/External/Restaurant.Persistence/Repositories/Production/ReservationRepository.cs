using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

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

        public async Task<List<Reservation>> ToListAsync(ISpecification<Reservation> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Reservations.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Reservation?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Reservation?> FindAsync(ISpecification<Reservation> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Reservations.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(Reservation reservation, CancellationToken cancellationToken = default)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
