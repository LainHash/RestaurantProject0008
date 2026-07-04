using Restaurant.Application.Features.Territory.Areas.Queries.GetAll;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.Areas;
using Restaurant.Domain.Repositories.Territory;
using System.Net;

namespace Restaurant.Persistence.Services.Territory
{
    internal class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<Result<IEnumerable<AreaResponse>>> GetAllAsync(GetAllAreasSpecification specification, CancellationToken cancellationToken = default)
        {
            var areas = await _areaRepository.GetAllAsync(specification, cancellationToken);

            var response = areas.Select(a => new AreaResponse(a));
            return Result<IEnumerable<AreaResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<AreaResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var area = await _areaRepository.FindAsync(id, cancellationToken);
            if (area == null)
            {
                return Result<AreaResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new AreaResponse(area);
            return Result<AreaResponse>
                .Succeed(response, Success.Retrieved);
        }
    }
}
