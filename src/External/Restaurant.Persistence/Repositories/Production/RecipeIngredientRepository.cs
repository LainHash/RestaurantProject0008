using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Production
{
    internal class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly RestaurantDbContext _context;

        public RecipeIngredientRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Task AddRangeAsync(IEnumerable<RecipeIngredient> recipeIngredients, CancellationToken cancellationToken = default)
        {
            _context.RecipeIngredients.AddRange(recipeIngredients);
            return Task.CompletedTask;
        }
    }
}
