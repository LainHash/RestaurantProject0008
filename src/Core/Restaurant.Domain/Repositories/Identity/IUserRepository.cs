using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Repositories.Identity
{
    public interface IUserRepository
    {
        Task<List<User>> ToListAsync(CancellationToken cancellationToken = default);
        Task<User?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> FindAsync(string emailOrUserName, CancellationToken cancellationToken = default);
    }
}
