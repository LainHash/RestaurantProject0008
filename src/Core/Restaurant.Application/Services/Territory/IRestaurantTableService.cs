using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Services.Territory
{
    public interface IRestaurantTableService
    {
        Task<Result<IEnumerable<RestaurantTableResponse>>> 
            GetAllAsync(CancellationToken cancellationToken = default);

        Task<Result<RestaurantTableResponse>> 
            GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<RestaurantTableResponse>>
            CreateAsync(CreateRestaurantTableRequest request, CancellationToken cancellationToken = default);

        Task<Result<RestaurantTableResponse>>
            UpdateAsync(Guid id, UpdateRestaurantTableRequest request, CancellationToken cancellationToken = default);

        Task<Result<object>>
            DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<object>>
            RestoreAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result<RestaurantTableResponse>>
            UpdateStatusAsync(Guid id, UpdateRestaurantTableStatusRequest request, CancellationToken cancellationToken = default);

    }
}
