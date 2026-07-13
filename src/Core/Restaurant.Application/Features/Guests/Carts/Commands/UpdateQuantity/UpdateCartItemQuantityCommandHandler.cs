using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.UpdateQuantity
{
    internal class UpdateCartItemQuantityCommandHandler
        : IRequestHandler<UpdateCartItemQuantityCommand, Result<CartResponse>
    {
        private readonly ICartService _cartService;

        public UpdateCartItemQuantityCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<CartResponse>> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateCartItemQuantitySpecification(request);
            var response = await _cartService.UpdateQuantityAsync(specification, cancellationToken);
            return response;
        }
    }
}
