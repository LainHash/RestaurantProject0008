using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;

namespace Restaurant.Application.Features.Guests.Carts.Commands.DeleteExpired
{
    internal class DeleteExpiredCartCommandHandler
        : IRequestHandler<DeleteExpiredCartCommand, Result<object>>
    {
        private readonly ICartService _cartService;

        public DeleteExpiredCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Result<object>> Handle(DeleteExpiredCartCommand request, CancellationToken cancellationToken)
        {
            var specification = new DeleteExpiredCartSpecification(request);
            var response = await _cartService.DeleteExpiredCartAsync(specification, cancellationToken);
            return response;
        }
    }
}
