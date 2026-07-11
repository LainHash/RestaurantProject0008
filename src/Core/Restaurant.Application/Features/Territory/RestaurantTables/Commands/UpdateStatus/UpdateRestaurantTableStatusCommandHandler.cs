using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.UpdateStatus
{
    internal class UpdateRestaurantTableStatusCommandHandler
        : IRequestHandler<UpdateRestaurantTableStatusCommand, Result<RestaurantTableResponse>>
    {
        private readonly IRestaurantTableService _restaurantTableService;

        public UpdateRestaurantTableStatusCommandHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        public async Task<Result<RestaurantTableResponse>> Handle(UpdateRestaurantTableStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.UpdateStatusAsync(request.Id, request.Body, cancellationToken);
            return response;
        }
    }
}
