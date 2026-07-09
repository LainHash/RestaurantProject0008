using MediatR;
using Restaurant.Application.Models.Abstraction;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.Areas;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetAll
{
    public record GetAllAreasQuery : PageQuery, IRequest<PageResult<IEnumerable<AreaResponse>>>
    {
    }
}

