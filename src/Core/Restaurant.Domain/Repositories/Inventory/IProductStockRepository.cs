using Restaurant.Domain.Entities.Inventory;

namespace Restaurant.Domain.Repositories.Inventory
{
    public interface IProductStockRepository
    {
        Task<ProductStock?> FindByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);
    }
}
