using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Territory
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Area>> GetAllAsync(ISpecification<Area> specification, CancellationToken cancellationToken = default);
        Task<Area?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
