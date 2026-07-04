using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Update
{
    public record UpdateRestaurantTableCommand(Guid Id, UpdateRestaurantTableRequest Body) : IRequest<Result<RestaurantTableResponse>>
    {
    }
}
