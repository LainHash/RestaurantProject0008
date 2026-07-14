using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Features.Production.Discounts.Queries.GetAll
{
    internal class GetAllDiscountsQueryHandler
        : IRequestHandler<GetAllDiscountsQuery, Result<IEnumerable<DiscountResponse>>>
    {
        private readonly IDiscountService _discountService;

        public GetAllDiscountsQueryHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<Result<IEnumerable<DiscountResponse>>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var response = await _discountService.GetAllAsync(cancellationToken);
            return response;
        }
    }
}
