using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Reservation?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
