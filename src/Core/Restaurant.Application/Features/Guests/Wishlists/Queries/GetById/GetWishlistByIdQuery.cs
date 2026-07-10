using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Queries.GetById
{
    public record GetWishlistByIdQuery(Guid Id)
        : IRequest<Result<WishlistRepsonse>>
    {
    }
}
