using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Queries.GetById
{
    public record GetPositionByIdQuery(Guid Id)
        : IRequest<Result<PositionResponse>>
    {
    }
}
