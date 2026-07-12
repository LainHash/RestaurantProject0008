using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Positions.Queries.GetAll
{
    public record GetAllPositionsQuery
        : IRequest<Result<IEnumerable<PositionResponse>>>
    {
    }
}
