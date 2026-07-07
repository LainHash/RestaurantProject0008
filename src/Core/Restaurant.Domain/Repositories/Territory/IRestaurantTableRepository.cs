using Restaurant.Domain.Entities.Territory;

namespace Restaurant.Domain.Repositories.Territory
{
    public interface IRestaurantTableRepository
    {
        Task<IEnumerable<RestaurantTable>>
            ToListAsync(CancellationToken cancellationToken = default);

        Task<RestaurantTable?>
            FindAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddAsync(RestaurantTable table, CancellationToken cancellationToken = default);

        Task UpdateAsync(RestaurantTable table, CancellationToken cancellationToken = default);


        Task<IEnumerable<RestaurantTable>>
            GetAvailableTablesAsync(
                string areaType,
                int minCapacity,
                DateTime reservationTime,
                TimeSpan duration,           // ví dụ: 2 tiếng
                CancellationToken cancellationToken = default);
    }
}
