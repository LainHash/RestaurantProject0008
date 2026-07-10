using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface ICartItemRepository
    {
        Task AddAsync(CartItem cartItem, CancellationToken cancellationToken = default);
        Task UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default);
    }
}
