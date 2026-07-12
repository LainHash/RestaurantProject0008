using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Features.Personnel.Queries.GetById
{
    internal class GetPositionByIdQueryHandler
        : IRequestHandler<GetPositionByIdQuery, Result<PositionResponse>>
    {
        private readonly IPositionService _positionService;

        public GetPositionByIdQueryHandler(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<Result<PositionResponse>> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _positionService.GetByIdAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
