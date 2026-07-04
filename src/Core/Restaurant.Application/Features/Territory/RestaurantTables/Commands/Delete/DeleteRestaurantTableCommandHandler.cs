using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Delete
{
    internal class DeleteRestaurantTableCommandHandler : IRequestHandler<DeleteRestaurantTableCommand, Result<object>>
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public DeleteRestaurantTableCommandHandler(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        public async Task<Result<object>> Handle(DeleteRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            var response = await _restaurantTableService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
