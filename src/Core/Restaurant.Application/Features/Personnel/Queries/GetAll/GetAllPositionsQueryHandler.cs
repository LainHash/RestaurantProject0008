using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Queries.GetAll
{
    internal class GetAllPositionsQueryHandler
        : IRequestHandler<GetAllPositionsQuery, Result<IEnumerable<PositionResponse>>>
    {
        private readonly IPositionService _positionService;

        public GetAllPositionsQueryHandler(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<Result<IEnumerable<PositionResponse>>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _positionService.GetAllAsync(cancellationToken);
            return response;
        }
    }
}
