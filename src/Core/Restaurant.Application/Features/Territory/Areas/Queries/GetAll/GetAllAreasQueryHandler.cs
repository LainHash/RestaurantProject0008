using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.Areas;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetAll
{
    internal class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, Result<IEnumerable<AreaResponse>>>
    {
        private readonly IAreaService _areaService;
        public GetAllAreasQueryHandler(IAreaService areaService)
        {
            _areaService = areaService;
        }
        public async Task<Result<IEnumerable<AreaResponse>>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllAreasSpecification(request);
            var response = await _areaService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
