using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Repositories.Catalog
{
    public interface ICategoryRepository
    {
        Task<List<Category>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Category?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Category category, CancellationToken cancellationToken = default);
        Task UpdateAsync(Category category, CancellationToken cancellationToken = default);
        Task DeleteAsync(CancellationToken cancellationToken = default);
    }
}
