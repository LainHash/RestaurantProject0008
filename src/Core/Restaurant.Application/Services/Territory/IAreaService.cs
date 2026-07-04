using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Territory.Areas;

namespace Restaurant.Application.Services.Territory
{
    public interface IAreaService
    {
        Task<Result<IEnumerable<AreaResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<AreaResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
