using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Features.Production.Discounts.Queries.GetAll
{
    public record GetAllDiscountsQuery
        : IRequest<Result<IEnumerable<DiscountResponse>>>
    {
    }
}
