using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Wishlists;
using Restaurant.Domain.Repositories.Guest;

namespace Restaurant.Application.Features.Guests.Wishlists.Commands.CreateForCustomer
{
    internal class CreateWishlistForCustomerCommandHandler
        : IRequestHandler<CreateWishlistForCustomerCommand, Result<WishlistRepsonse>>
    {
        private readonly IWishlistService _wishlistService;

        public CreateWishlistForCustomerCommandHandler(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<Result<WishlistRepsonse>> Handle(CreateWishlistForCustomerCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateWishlistForCustomerSpecification(request);
            var response = await _wishlistService.CreateForCustomerAsync(specification, cancellationToken);
            return response;
        }
    }
}
