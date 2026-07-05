using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

namespace Restaurant.Persistence.Repositories.Catalog
{
    internal class ProductRepository : IProductRepository
    {
        private readonly RestaurantDbContext _context;
        public ProductRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> ToListAsync(ISpecification<Product> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Products.AsQueryable(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Product?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Product?> FindAsync(ISpecification<Product> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Products.AsQueryable(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            _context.Products.RemoveRange(_context.Products);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
