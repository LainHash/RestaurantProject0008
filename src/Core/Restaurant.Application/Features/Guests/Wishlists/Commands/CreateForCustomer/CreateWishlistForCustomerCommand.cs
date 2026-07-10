using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer
{
    public record CreateWishlistForCustomerCommand(Guid UserId)
        : IRequest<Result<WishlistRepsonse>>
    {
    }
}
