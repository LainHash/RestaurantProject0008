using Restaurant.Application.Features.Territory.Areas.Queries.GetAll;
using Restaurant.Application.Features.Territory.Areas.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.Areas;
using Restaurant.Domain.Entities.Territory;
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

        public async Task<PageResult<IEnumerable<AreaResponse>>> GetAllAsync(GetAllAreasSpecification specification, CancellationToken cancellationToken = default)
        {
            var totalItems = await _areaRepository.CountAsync(specification, cancellationToken);
            var indexPage = (specification.Skip / specification.Take) + 1;

            var areas = await _areaRepository.GetAllAsync(specification, cancellationToken);

            var response = areas.Select(a => new AreaResponse(a));
            return PageResult<IEnumerable<AreaResponse>>
                .Succeed(response, Success<Area>.Retrieved, totalItems, indexPage, specification.Take);
        }

        public async Task<Result<AreaResponse>> GetByIdAsync(GetAreaByIdSpecification specification, CancellationToken cancellationToken = default)
        {
            var area = await _areaRepository.FindAsync(specification, cancellationToken);
            if (area is null)
            {
                return Result<AreaResponse>
                    .Fail(Error<Area>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new AreaResponse(area);
            return Result<AreaResponse>
                .Succeed(response, Success<Area>.Retrieved);
        }
    }
}
