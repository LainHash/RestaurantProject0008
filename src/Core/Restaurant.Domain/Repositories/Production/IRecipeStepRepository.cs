using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IRecipeStepRepository
    {
        Task AddRangeAsync(
            IEnumerable<RecipeStep> recipeSteps,
            CancellationToken cancellationToken);
    }
}
