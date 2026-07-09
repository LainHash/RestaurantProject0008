using Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer;
using Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Services.Production
{
    public interface IReservationService
    {
        Task<PageResult<IEnumerable<ReservationResponse>>> 
            GetAllAsync(GetAllReservationsSpecification specification, CancellationToken cancellationToken = default);

        Task<PageResult<IEnumerable<ReservationResponse>>>
            GetAllByWeekAsync(GetAllReservationsByWeekSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ReservationResponse>> 
            GetByIdAsync(GetReservationByIdSpecification specification, CancellationToken cancellationToken = default);

        Task<Result<ReservationResponse>>
            CreateForCustomerAsync(CreateReservationForCustomerSpecification specification, CancellationToken cancellationToken = default);
        
        Task<Result<ReservationResponse>>
            CreateForGuestAsync(CreateReservationForGuestSpecification specification, CancellationToken cancellationToken = default);
    }
}
