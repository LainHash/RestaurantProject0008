using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Catalog
{
    public interface IProductRepository
    {
        Task<List<Product>> ToListAsync(ISpecification<Product> specification, CancellationToken cancellationToken = default);
        Task<Product?> FindAsync(ISpecification<Product> specification, CancellationToken cancellationToken = default);
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task DeleteAsync(CancellationToken cancellationToken = default);
    }
}
