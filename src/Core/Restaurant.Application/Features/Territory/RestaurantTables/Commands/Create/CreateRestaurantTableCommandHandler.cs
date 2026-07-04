using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Create
{
    internal class CreateRestaurantTableCommandHandler : IRequestHandler<CreateRestaurantTableCommand, Result<RestaurantTableResponse>>
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public CreateRestaurantTableCommandHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        public async Task<Result<RestaurantTableResponse>> Handle(CreateRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
