using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Repositories.Catalog
{
    public interface IIngredientRepository 
    {
        Task<List<Ingredient>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Ingredient?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
        Task UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    }
}
