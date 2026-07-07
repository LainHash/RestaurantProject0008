using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Services.Production
{
    public interface IRecipeService
    {
        Task<Result<IEnumerable<RecipeResponse>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<RecipeResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
