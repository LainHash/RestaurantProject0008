using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Repositories.Identity
{
    public interface IProfileRepository
    {
        Task<List<Profile>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Profile?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Profile profile, CancellationToken cancellationToken = default);
    }
}
