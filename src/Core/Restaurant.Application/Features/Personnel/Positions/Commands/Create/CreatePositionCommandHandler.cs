using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Positions.Commands.Create
{
    internal class CreatePositionCommandHandler
        : IRequestHandler<CreatePositionCommand, Result<PositionResponse>>
    {
        private readonly IPositionService _positionService;

        public CreatePositionCommandHandler(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<Result<PositionResponse>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var response = await _positionService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
