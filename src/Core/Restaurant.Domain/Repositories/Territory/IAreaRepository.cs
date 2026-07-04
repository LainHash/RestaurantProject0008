using Restaurant.Domain.Entities.Territory;

namespace Restaurant.Domain.Repositories.Territory
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Area?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
