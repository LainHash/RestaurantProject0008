using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Services.Production
{
    public interface IReservationService
    {
        Task<Result<IEnumerable<ReservationResponse>>> 
            GetAllAsync(GetAllReservationsSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ReservationResponse>> 
            GetByIdAsync(GetReservationByIdSpecification specification, CancellationToken cancellationToken = default);
    }
}
