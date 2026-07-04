using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.Areas;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetById
{
    public record GetAreaByIdQuery(Guid Id) : IRequest<Result<AreaResponse>>;
}
