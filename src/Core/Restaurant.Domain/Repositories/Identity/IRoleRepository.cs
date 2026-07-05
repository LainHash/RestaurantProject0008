using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Repositories.Identity
{
    public interface IRoleRepository
    {
        Task<List<Role>> ToListAsync(CancellationToken cancellationToken);
        Task<Role?> FindAsync(Guid id,  CancellationToken cancellationToken);
        Task<Role?> FindAsync(string name, CancellationToken cancellationToken);
    }
}
