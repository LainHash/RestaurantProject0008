using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Restore
{
    internal class RestoreRestaurantTableCommandHandler : IRequestHandler<RestoreRestaurantTableCommand, Result<object>>
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public RestoreRestaurantTableCommandHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        public async Task<Result<object>> Handle(RestoreRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
