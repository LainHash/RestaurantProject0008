using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IRecipeIngredientRepository
    {
        Task AddRangeAsync(IEnumerable<RecipeIngredient> recipeIngredients,CancellationToken cancellationToken = default);
    }
}
