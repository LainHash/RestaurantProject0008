using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.AddItem
{
    internal class AddWishlistItemCommandHandler
        : IRequestHandler<AddWishlistItemCommand, Result<WishlistRepsonse>>
    {
        private readonly IWishlistService _wishlistService;

        public AddWishlistItemCommandHandler(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<Result<WishlistRepsonse>> Handle(AddWishlistItemCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddWishlistItemSpecification(request);
            var response = await _wishlistService.AddItemAsync(specification, cancellationToken);
            return response;
        }
    }
}
