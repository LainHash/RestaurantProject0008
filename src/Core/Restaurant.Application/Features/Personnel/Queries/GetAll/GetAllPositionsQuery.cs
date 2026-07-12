using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Queries.GetAll
{
    public record GetAllPositionsQuery
        : IRequest<Result<IEnumerable<PositionResponse>>>
    {
    }
}
