using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Positions.Commands.Create
{
    public record CreatePositionCommand(CreatePositionRequest Body)
        : IRequest<Result<PositionResponse>>
    {
    }
}
