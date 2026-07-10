using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest
{
    public record CreateWishlistForGuestCommand(Guid SessionId)
        : IRequest<Result<WishlistRepsonse>>
    {
    }
}
