using Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Contract.DTOs.Guests.Wishlists;
using Restaurant.Domain.Repositories.Guest;
using System.Net;

namespace Restaurant.Persistence.Services.Guests
{
    internal class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<Result<IEnumerable<WishlistRepsonse>>> GetAllAsync(GetAllWishlistsSpecification specification, CancellationToken cancellationToken)
        {
            var wishlists = await _wishlistRepository.ToListAsync(specification, cancellationToken);

            var response = wishlists.Select(x => new WishlistRepsonse(x));
            return Result<IEnumerable<WishlistRepsonse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<WishlistRepsonse>> GetByIdAsync(GetWishlistByIdSpecification specification, CancellationToken cancellationToken)
        {
            var wishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);
            if (wishlist is null)
            {
                return Result<WishlistRepsonse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new WishlistRepsonse(wishlist);
            return Result<WishlistRepsonse>
                    .Succeed(response, Success.Retrieved);
        }
    }
}
