using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.UpdateStatus
{
    public record UpdateRestaurantTableStatusCommand(Guid Id, UpdateRestaurantTableStatusRequest Body)
        : IRequest<Result<RestaurantTableResponse>>
    {
    }
}
