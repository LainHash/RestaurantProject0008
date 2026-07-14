using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Features.Production.Discounts.Commands.Create
{
    public record CreateDiscountCommand(CreateDiscountRequest Body)
        : IRequest<Result<DiscountResponse>>
    {
    }
}
