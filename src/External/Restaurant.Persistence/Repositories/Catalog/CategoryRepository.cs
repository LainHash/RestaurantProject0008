using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Persistence.Repositories.Catalog
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly RestaurantDbContext _context;
        public CategoryRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }

        public async Task<Category?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            _context.Categories.RemoveRange(_context.Categories);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
