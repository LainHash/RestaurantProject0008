using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

namespace Restaurant.Persistence.Repositories.Production
{
    internal class RecipeRepository : IRecipeRespository
    {
        private readonly RestaurantDbContext _context;
        public RecipeRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Recipes.ToListAsync(cancellationToken);
        }

        public async Task<List<Recipe>> ToListAsync(ISpecification<Recipe> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Recipes.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Recipe?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<Recipe?> FindAsync(ISpecification<Recipe> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Recipes.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(Recipe recipe, CancellationToken cancellationToken = default)
        {
            _context.Recipes.Add(recipe);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Recipe recipe, CancellationToken cancellationToken = default)
        {
            _context.Recipes.Update(recipe);
            return Task.CompletedTask;
        }
    }
}
