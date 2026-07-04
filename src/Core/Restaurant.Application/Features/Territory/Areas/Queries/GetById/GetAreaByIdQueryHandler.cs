using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.Areas;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetById
{
    internal class GetAreaByIdQueryHandler : IRequestHandler<GetAreaByIdQuery, Result<AreaResponse>>
    {
        private readonly IAreaService _areaService;
        public GetAreaByIdQueryHandler(IAreaService areaService)
        {
            _areaService = areaService;
        }
        public async Task<Result<AreaResponse>> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAreaByIdSpecification(request);
            var response = await _areaService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
