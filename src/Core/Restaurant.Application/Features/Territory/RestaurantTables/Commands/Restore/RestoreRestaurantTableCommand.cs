using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Commands.Restore
{
    public record RestoreRestaurantTableCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
