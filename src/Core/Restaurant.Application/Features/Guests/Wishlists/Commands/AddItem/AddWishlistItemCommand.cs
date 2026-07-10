using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.AddItem
{
    public record AddWishlistItemCommand(Guid WishlistId, Guid ProductId)
        : IRequest<Result<WishlistRepsonse>>
    {
    }
}
