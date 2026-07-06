using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Services.Production
{
    public interface IReservationService
    {
        Task<Result<IEnumerable<ReservationResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<ReservationResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
