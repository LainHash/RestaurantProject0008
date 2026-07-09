using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

namespace Restaurant.Persistence.Repositories.Catalog
{
    internal class IngredientRepository : IIngredientRepository
    {
        private readonly RestaurantDbContext _context;
        public IngredientRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ingredient>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Ingredients.ToListAsync(cancellationToken);
        }

        public Task<List<Ingredient>> ToListAsync(ISpecification<Ingredient> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Ingredients.AsQueryable().AsNoTracking(), specification);
            return query.ToListAsync(cancellationToken);
        }

        public async Task<Ingredient?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public Task<Ingredient?> FindAsync(ISpecification<Ingredient> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Ingredients.AsQueryable().AsNoTracking(), specification);
            return query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
        {
            _context.Ingredients.Add(ingredient);
            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<Ingredient> ingredients, CancellationToken cancellationToken = default)
        {
            _context.Ingredients.AddRange(ingredients);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
        {
            _context.Ingredients.Update(ingredient);
            return Task.CompletedTask;
        }

        public async Task<int> CountAsync(ISpecification<Ingredient> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Ingredients.AsQueryable().AsNoTracking(), specification, applyPaging: false);
            return await query.CountAsync(cancellationToken);
        }
    }
}
