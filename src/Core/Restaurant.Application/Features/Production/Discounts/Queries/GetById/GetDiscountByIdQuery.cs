using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Features.Production.Discounts.Queries.GetById
{
    public record GetDiscountByIdQuery(Guid Id)
        : IRequest<Result<DiscountResponse>>
    {
    }
}
