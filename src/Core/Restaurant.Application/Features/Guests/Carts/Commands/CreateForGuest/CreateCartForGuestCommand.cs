using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.CreateForGuest
{
    public record CreateCartForGuestCommand(Guid SessionId)
        : IRequest<Result<CartResponse>>
    {
    }
}
