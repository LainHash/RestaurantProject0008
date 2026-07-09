using Restaurant.Application.Features.Guests.Carts.Queries.GetAll;
using Restaurant.Application.Features.Guests.Carts.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using System.Net;

namespace Restaurant.Persistence.Services.Guests
{
    internal class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<IEnumerable<CartResponse>>>
            GetAllAsync(GetAllCartsSpecification specification, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.ToListAsync(specification, cancellationToken);

            var response = carts.Select(x => new CartResponse(x));
            return Result<IEnumerable<CartResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<CartResponse>> 
            GetByIdAsync(GetCartByIdSpecification specification, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.FindAsync(specification, cancellationToken);
            if (cart is null)
            {
                return Result<CartResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new CartResponse(cart);
            return Result<CartResponse>
                .Succeed(response, Success.Retrieved);
        }
    }
}
