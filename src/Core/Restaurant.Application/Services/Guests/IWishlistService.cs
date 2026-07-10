using Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Wishlists;

namespace Restaurant.Application.Services.Guests
{
    public interface IWishlistService
    {
        Task<Result<IEnumerable<WishlistRepsonse>>> 
            GetAllAsync(GetAllWishlistsSpecification specification, CancellationToken cancellationToken);

        Task<Result<WishlistRepsonse>>
            GetByIdAsync(GetWishlistByIdSpecification specification, CancellationToken cancellationToken);
    }
}
