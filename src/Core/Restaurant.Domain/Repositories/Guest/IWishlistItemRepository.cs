using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface IWishlistItemRepository
    {
        Task AddAsync(WishlistItem wishlistItem, CancellationToken cancellationToken = default);
    }
}
