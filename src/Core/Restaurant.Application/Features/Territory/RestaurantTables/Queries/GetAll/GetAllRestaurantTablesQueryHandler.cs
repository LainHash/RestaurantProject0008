using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Queries.GetAll
{
    internal class GetAllRestaurantTablesQueryHandler 
        : IRequestHandler<GetAllRestaurantTablesQuery, Result<IEnumerable<RestaurantTableResponse>>>
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public GetAllRestaurantTablesQueryHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }
        public async Task<Result<IEnumerable<RestaurantTableResponse>>> Handle(GetAllRestaurantTablesQuery request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.GetAllAsync(cancellationToken);
            return response;
        }
    }
}
