using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Production
{
    public interface IRecipeRespository
    {
        Task<List<Recipe>> ToListAsync(CancellationToken cancellationToken = default);
        Task<List<Recipe>> ToListAsync(ISpecification<Recipe> specification, CancellationToken cancellationToken = default);
        Task<Recipe?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Recipe?> FindAsync(ISpecification<Recipe> specification, CancellationToken cancellationToken = default);
    }
}
