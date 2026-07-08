using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Catalog
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> ToListAsync(CancellationToken cancellationToken = default);
        Task<List<Ingredient>> ToListAsync(ISpecification<Ingredient> specification, CancellationToken cancellationToken = default);
        Task<Ingredient?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Ingredient?> FindAsync(ISpecification<Ingredient> specification, CancellationToken cancellationToken = default);
        Task AddAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<Ingredient> ingredients, CancellationToken cancellationToken = default);
        Task UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    }
}
