using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.CreateForGuest
{
    internal class CreateCartForGuestCommandHandler
        : IRequestHandler<CreateCartForGuestCommand, Result<CartResponse>>
    {
        private readonly ICartService _cartService;

        public CreateCartForGuestCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<CartResponse>> Handle(CreateCartForGuestCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateCartForGuestSpecification(request);
            var response = await _cartService.CreateForGuestAsync(specification, cancellationToken);
            return response;
        }
    }
}
