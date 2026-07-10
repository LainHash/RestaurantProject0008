using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Queries.GetById
{
    internal class GetWishlistByIdQueryHandler
        : IRequestHandler<GetWishlistByIdQuery, Result<WishlistRepsonse>>
    {
        private readonly IWishlistService _wishlistService;

        public GetWishlistByIdQueryHandler(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<Result<WishlistRepsonse>> Handle(GetWishlistByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetWishlistByIdSpecification(request);
            var response = await _wishlistService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
