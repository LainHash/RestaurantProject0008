using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;
using Restaurant.Domain.Repositories.Territory;
using System.Net;

namespace Restaurant.Persistence.Services.Territory
{
    internal class RestaurantTableService : IRestaurantTableService
    {
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        public RestaurantTableService(IRestaurantTableRepository restaurantTableRepository)
        {
            _restaurantTableRepository = restaurantTableRepository;
        }

        public async Task<Result<IEnumerable<RestaurantTableResponse>>> 
            GetAllAsync(CancellationToken cancellationToken = default)
        {
            var restaurantTables = await _restaurantTableRepository.ToListAsync(cancellationToken);

            var response = restaurantTables.Select(rt => new RestaurantTableResponse(rt));
            return Result<IEnumerable<RestaurantTableResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RestaurantTableResponse>> 
            GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restaurantTable = await _restaurantTableRepository.FindAsync(id, cancellationToken);
            if (restaurantTable is null)
            {
                return Result<RestaurantTableResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new RestaurantTableResponse(restaurantTable);
            return Result<RestaurantTableResponse>
                .Succeed(response, Success.Retrieved);
        }
    }
}
