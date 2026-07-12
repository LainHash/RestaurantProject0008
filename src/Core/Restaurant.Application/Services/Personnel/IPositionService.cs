using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Positions;

namespace Restaurant.Application.Services.Personnel
{
    public interface IPositionService
    {
        Task<Result<IEnumerable<PositionResponse>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<PositionResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Result<PositionResponse>> CreateAsync(CreatePositionRequest request, CancellationToken cancellationToken);
    }
}
