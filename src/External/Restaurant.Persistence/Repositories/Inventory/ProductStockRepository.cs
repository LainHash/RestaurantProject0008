using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Repositories.Inventory;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Inventory
{
    internal class ProductStockRepository : IProductStockRepository
    {
        private readonly RestaurantDbContext _context;

        public ProductStockRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<ProductStock?> FindByProductIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _context.ProductStocks.FirstOrDefaultAsync(x => x.ProductId == productId, cancellationToken);
        }
    }
}
