using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Queries.GetAll
{
    internal class GetAllCartsQueryHandler
        : IRequestHandler<GetAllCartsQuery, Result<IEnumerable<CartResponse>>>
    {
        private readonly ICartService _cartService;

        public GetAllCartsQueryHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<IEnumerable<CartResponse>>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllCartsSpecification(request);
            var response = await _cartService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
