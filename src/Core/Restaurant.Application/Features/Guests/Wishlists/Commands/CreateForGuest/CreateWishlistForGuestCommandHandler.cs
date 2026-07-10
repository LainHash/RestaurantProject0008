using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest
{
    internal class CreateWishlistForGuestCommandHandler
        : IRequestHandler<CreateWishlistForGuestCommand, Result<WishlistRepsonse>>
    {
        private readonly IWishlistService _wishlistService;

        public CreateWishlistForGuestCommandHandler(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<Result<WishlistRepsonse>> Handle(CreateWishlistForGuestCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateWishlistForGuestSpecification(request);
            var response = await _wishlistService.CreateForGuestAsync(specification, cancellationToken);
            return response;
        }
    }
}
