using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Persistence.Contexts;

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

        public async Task<Recipe?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }
    }
}
