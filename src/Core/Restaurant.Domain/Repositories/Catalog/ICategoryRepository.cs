using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Catalog
{
    public interface ICategoryRepository
    {
        Task<List<Category>> ToListAsync(CancellationToken cancellationToken = default);
        Task<List<Category>> ToListAsync(ISpecification<Category> specification, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<Category> specification, CancellationToken cancellationToken = default);
        Task<Category?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Category category, CancellationToken cancellationToken = default);
        Task UpdateAsync(Category category, CancellationToken cancellationToken = default);
        Task DeleteAsync(CancellationToken cancellationToken = default);
    }
}
