using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Queries.GetById
{
    internal class GetCartByIdQueryHandler
        : IRequestHandler<GetCartByIdQuery, Result<CartResponse>>
    {
        private readonly ICartService _cartService;

        public GetCartByIdQueryHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<CartResponse>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetCartByIdSpecification(request);
            var response = await _cartService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
