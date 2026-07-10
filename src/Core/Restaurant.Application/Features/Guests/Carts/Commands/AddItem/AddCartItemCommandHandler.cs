using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.AddItem
{
    internal class AddCartItemCommandHandler
        : IRequestHandler<AddCartItemCommand, Result<CartResponse>>
    {
        private readonly ICartService _cartService;

        public AddCartItemCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<CartResponse>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddCartItemSpecification(request);
            var response = await _cartService.AddItemAsync(specification, cancellationToken);
            return response;
        }
    }
}
