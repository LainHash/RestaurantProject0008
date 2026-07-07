using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IRecipeRespository
    {
        Task<List<Recipe>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Recipe?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
