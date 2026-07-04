using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Update
{
    internal class UpdateRestaurantTableCommandHandler : IRequestHandler<UpdateRestaurantTableCommand, Result<RestaurantTableResponse>>
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public UpdateRestaurantTableCommandHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }
        public async Task<Result<RestaurantTableResponse>> Handle(UpdateRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.UpdateAsync(request.Id, request.Body, cancellationToken);
            return response;
        }
    }
}
