using Restaurant.Application.Features.Guests.Wishlists.Commands.AddItem;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Wishlists.Commands.DeleteExpired;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetAll;
using Restaurant.Application.Features.Guests.Wishlists.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Application.Services.Persistence;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Contract.DTOs.Guests.Wishlists;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using System.Net;

namespace Restaurant.Persistence.Services.Guests
{
    internal class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WishlistService(
            IWishlistRepository wishlistRepository,
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository,
            IWishlistItemRepository wishlistItemRepository)
        {
            _wishlistRepository = wishlistRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _wishlistItemRepository = wishlistItemRepository;
        }

        public async Task<Result<IEnumerable<WishlistRepsonse>>> GetAllAsync(GetAllWishlistsSpecification specification, CancellationToken cancellationToken)
        {
            var wishlists = await _wishlistRepository.ToListAsync(specification, cancellationToken);

            var response = wishlists.Select(x => new WishlistRepsonse(x));
            return Result<IEnumerable<WishlistRepsonse>>
                .Succeed(response, Success<Wishlist>.Retrieved);
        }

        public async Task<Result<WishlistRepsonse>> GetByIdAsync(GetWishlistByIdSpecification specification, CancellationToken cancellationToken)
        {
            var wishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);
            if (wishlist is null)
            {
                return Result<WishlistRepsonse>
                    .Fail(Error<Wishlist>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new WishlistRepsonse(wishlist);
            return Result<WishlistRepsonse>
                    .Succeed(response, Success<Wishlist>.Retrieved);
        }

        public async Task<Result<WishlistRepsonse>> CreateForGuestAsync(CreateWishlistForGuestSpecification specification, CancellationToken cancellationToken)
        {
            var wishlist = new Wishlist();

            wishlist.SetGuest(specification.SessionId);
            await _wishlistRepository.AddAsync(wishlist, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(wishlist.Id);
            var createdWishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);

            var response = new WishlistRepsonse(createdWishlist!);
            return Result<WishlistRepsonse>
                    .Succeed(response, Success<Wishlist>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<WishlistRepsonse>> CreateForCustomerAsync(CreateWishlistForCustomerSpecification specification, CancellationToken cancellationToken)
        {
            var wishlist = new Wishlist();

            var customer = await _customerRepository.FindByUserIdAsync(specification.UserId, cancellationToken);
            if (customer is null)
            {
                return Result<WishlistRepsonse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            wishlist.SetCustomer(customer.Id);
            await _wishlistRepository.AddAsync(wishlist, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(wishlist.Id);
            var createdWishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);

            var response = new WishlistRepsonse(createdWishlist!);
            return Result<WishlistRepsonse>
                    .Succeed(response, Success<Wishlist>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<WishlistRepsonse>> AddItemAsync(AddWishlistItemSpecification specification, CancellationToken cancellationToken)
        {
            var wishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);
            if (wishlist is null)
            {
                return Result<WishlistRepsonse>
                    .Fail(Error<Wishlist>.NotFound, HttpStatusCode.NotFound);
            }

            var existingItem = wishlist.WishlistItems.Any(x => x.ProductId == specification.ProductId);
            if (existingItem)
            {
                return Result<WishlistRepsonse>
                    .Fail(Error<WishlistItem>.AlreadyAdded, HttpStatusCode.Conflict);
            }

            var item = new WishlistItem(wishlist.Id, specification.ProductId);
            await _wishlistItemRepository.AddAsync(item, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new WishlistRepsonse(wishlist);
            return Result<WishlistRepsonse>
                    .Succeed(response, Success<WishlistItem>.Added);
        }

        public async Task<Result<object>> 
            DeleteExpiredWishlistAsync(DeleteExpiredWishlistSpecification specification, CancellationToken cancellationToken)
        {
            var wishlists = await _wishlistRepository.ToListAsync(specification, cancellationToken);

            var count = _wishlistRepository.RemoveRange(wishlists, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(count, Success<Wishlist>.Deleted);
        }
    }
}
