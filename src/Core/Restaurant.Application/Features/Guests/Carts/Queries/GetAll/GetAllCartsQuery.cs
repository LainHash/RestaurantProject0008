using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Queries.GetAll
{
    public record GetAllCartsQuery 
        : IRequest<Result<IEnumerable<CartResponse>>>
    {
    }
}
