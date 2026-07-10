using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.AddItem
{
    public record AddCartItemCommand(Guid CartId, Guid ProductId)
        : IRequest<Result<CartResponse>>
    {
    }
}
