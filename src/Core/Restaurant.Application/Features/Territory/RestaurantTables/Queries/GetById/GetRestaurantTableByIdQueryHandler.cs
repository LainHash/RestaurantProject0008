using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Queries.GetById
{
    internal class GetRestaurantTableByIdQueryHandler : IRequestHandler<GetRestaurantTableByIdQuery, Result<RestaurantTableResponse>>
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public GetRestaurantTableByIdQueryHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        public async Task<Result<RestaurantTableResponse>> Handle(GetRestaurantTableByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.GetByIdAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
