using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll
{
    internal class GetAllWishlistsQueryHandler
        : IRequestHandler<GetAllWishlistsQuery, Result<IEnumerable<WishlistRepsonse>>>
    {
        private readonly IWishlistService _wishlistService;

        public GetAllWishlistsQueryHandler(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<Result<IEnumerable<WishlistRepsonse>>> Handle(GetAllWishlistsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllWishlistsSpecification(request);
            var response = await _wishlistService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
