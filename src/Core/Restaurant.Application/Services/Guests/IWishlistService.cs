using Restaurant.Application.Features.Guests.Wishlists.Commands.AddItem;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Wishlists.Commands.DeleteExpired;
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

        Task<Result<WishlistRepsonse>>
            CreateForGuestAsync(CreateWishlistForGuestSpecification specification, CancellationToken cancellationToken);

        Task<Result<WishlistRepsonse>>
            CreateForCustomerAsync(CreateWishlistForCustomerSpecification specification, CancellationToken cancellationToken);

        Task<Result<WishlistRepsonse>>
            AddItemAsync(AddWishlistItemSpecification specification, CancellationToken cancellationToken);

        Task<Result<object>>
            DeleteExpiredWishlistAsync(DeleteExpiredWishlistSpecification specification, CancellationToken cancellationToken);
    }
}
