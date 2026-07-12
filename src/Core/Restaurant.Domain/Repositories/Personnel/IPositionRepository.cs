using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Domain.Repositories.Personnel
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Position?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
