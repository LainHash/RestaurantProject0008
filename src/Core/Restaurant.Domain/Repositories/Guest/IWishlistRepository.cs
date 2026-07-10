using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface IWishlistRepository
    {
        Task<IEnumerable<Wishlist>> ToListAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Wishlist>> ToListAsync(ISpecification<Wishlist> specification, CancellationToken cancellationToken = default);
        Task<Wishlist?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Wishlist?> FindAsync(ISpecification<Wishlist> specification, CancellationToken cancellationToken = default);
        Task AddAsync(Wishlist wishlist, CancellationToken cancellationToken = default);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
