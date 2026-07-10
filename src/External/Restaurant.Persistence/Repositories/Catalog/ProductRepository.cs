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
                .GetQuery(_context.Products.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Product?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Product?> FindAsync(ISpecification<Product> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Products.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Update(product);
            return Task.CompletedTask;
        }

        public async Task<int> CountAsync(ISpecification<Product> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Products.AsQueryable().AsNoTracking(), specification, applyPaging: false);
            return await query.CountAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
