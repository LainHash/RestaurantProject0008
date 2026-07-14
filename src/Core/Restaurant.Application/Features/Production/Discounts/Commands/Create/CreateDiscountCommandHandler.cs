using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Features.Production.Discounts.Commands.Create
{
    internal class CreateDiscountCommandHandler
        : IRequestHandler<CreateDiscountCommand, Result<DiscountResponse>>
    {
        private readonly IDiscountService _discountService;

        public CreateDiscountCommandHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Result<DiscountResponse>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var response = await _discountService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
