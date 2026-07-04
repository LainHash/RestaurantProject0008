using Restaurant.Domain.Entities.Territory;

namespace Restaurant.Domain.Repositories.Territory
{
    public interface IRestaurantTableRepository
    {
        Task<IEnumerable<RestaurantTable>>
            ToListAsync(CancellationToken cancellationToken = default);

        Task<RestaurantTable?>
            FindAsync(Guid id, CancellationToken cancellationToken = default);

        Task<RestaurantTable>
            AddAsync(RestaurantTable table, CancellationToken cancellationToken = default);

        Task<RestaurantTable>
            UpdateAsync(RestaurantTable table, CancellationToken cancellationToken = default);
    }
}
