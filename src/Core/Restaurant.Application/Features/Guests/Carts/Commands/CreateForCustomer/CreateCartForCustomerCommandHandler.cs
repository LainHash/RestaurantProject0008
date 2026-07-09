using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.CreateForCustomer
{
    internal class CreateCartForCustomerCommandHandler
        : IRequestHandler<CreateCartForCustomerCommand, Result<CartResponse>>
    {
        private readonly ICartService _cartService;

        public CreateCartForCustomerCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<CartResponse>> Handle(CreateCartForCustomerCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateCartForCustomerSpecification(request);
            var response = await _cartService.CreateForCustomerAsync(specification, cancellationToken);
            return response;
        }
    }
}
