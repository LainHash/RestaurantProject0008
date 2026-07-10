using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll
{
    public record GetAllWishlistsQuery
        : IRequest<Result<IEnumerable<WishlistRepsonse>>>
    {
    }
}
