using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Delete
{
    public record DeleteRestaurantTableCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
