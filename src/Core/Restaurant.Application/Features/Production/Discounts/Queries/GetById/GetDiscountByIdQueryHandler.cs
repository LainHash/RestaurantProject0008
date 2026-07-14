using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Features.Production.Discounts.Queries.GetById
{
    internal class GetDiscountByIdQueryHandler
        : IRequestHandler<GetDiscountByIdQuery, Result<DiscountResponse>>
    {
        private readonly IDiscountService _discountService;

        public GetDiscountByIdQueryHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Result<DiscountResponse>> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _discountService.GetByIdAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
