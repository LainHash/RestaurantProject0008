using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Guest
{
    internal class WishlistItemRepository : IWishlistItemRepository
    {
        private readonly RestaurantDbContext _context;

        public WishlistItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(WishlistItem wishlistItem, CancellationToken cancellationToken = default)
        {
            _context.WishlistItems.Add(wishlistItem);
            return Task.CompletedTask;
        }
    }
}
