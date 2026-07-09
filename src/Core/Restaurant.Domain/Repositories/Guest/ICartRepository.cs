using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Cart?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Cart cart, CancellationToken cancellationToken = default);
    }
}
