using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Create
{
    public record CreateRestaurantTableCommand(CreateRestaurantTableRequest Body) : IRequest<Result<RestaurantTableResponse>>
    {
    }
}
