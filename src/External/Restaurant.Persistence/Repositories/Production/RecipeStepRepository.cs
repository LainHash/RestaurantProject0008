using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Production
{
    internal class RecipeStepRepository : IRecipeStepRepository
    {
        private readonly RestaurantDbContext _context;

        public RecipeStepRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Task AddRangeAsync(IEnumerable<RecipeStep> recipeSteps, CancellationToken cancellationToken)
        {
            _context.RecipeSteps.AddRange(recipeSteps);
            return Task.CompletedTask;
        }
    }
}
