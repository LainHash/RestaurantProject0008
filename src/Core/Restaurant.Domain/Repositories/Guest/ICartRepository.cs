using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> ToListAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Cart>> ToListAsync(ISpecification<Cart> specification, CancellationToken cancellationToken = default);
        Task<Cart?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Cart?> FindAsync(ISpecification<Cart> specification, CancellationToken cancellationToken = default);
        Task AddAsync(Cart cart, CancellationToken cancellationToken = default);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
