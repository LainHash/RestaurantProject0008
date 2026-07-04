using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Queries.GetById
{
    public record GetRestaurantTableByIdQuery(Guid Id) : IRequest<Result<RestaurantTableResponse>>
    {
    }
}
