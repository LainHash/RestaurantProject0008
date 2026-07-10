using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.DeleteExpired
{
    public record DeleteExpiredWishlistCommand(IEnumerable<Guid> WishlistIds)
        : IRequest<Result<object>>
    {
    }
}
