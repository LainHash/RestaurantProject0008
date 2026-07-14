using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Discount?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Discount discount, CancellationToken cancellationToken = default);
    }
}
