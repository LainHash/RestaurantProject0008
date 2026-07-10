using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.DeleteExpired
{
    internal class DeleteExpiredWishlistCommandHandler
        : IRequestHandler<DeleteExpiredWishlistCommand, Result<object>>
    {
        private readonly IWishlistService _wishlistService;

        public DeleteExpiredWishlistCommandHandler(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<Result<object>> Handle(DeleteExpiredWishlistCommand request, CancellationToken cancellationToken)
        {
            var response = await _wishlistService.DeleteExpiredWishlistAsync(request.WishlistIds, cancellationToken);
            return response;
        }
    }
}
