using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Queries.GetAll
{
    public record GetAllRestaurantTablesQuery : IRequest<Result<IEnumerable<RestaurantTableResponse>>>
    {
    }
}
