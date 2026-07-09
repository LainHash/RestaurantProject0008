using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> ToListAsync(CancellationToken cancellationToken = default);
        Task<List<Reservation>> ToListAsync(ISpecification<Reservation> specification, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<Reservation> specification, CancellationToken cancellationToken = default);
        Task<Reservation?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Reservation?> FindAsync(ISpecification<Reservation> specification, CancellationToken cancellationToken = default);
        Task AddAsync(Reservation reservation, CancellationToken cancellationToken = default);
        Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default);

    }
}
