using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Queries.GetById
{
    public record GetCartByIdQuery(Guid Id) : IRequest<Result<CartResponse>>
    {
    }
}
