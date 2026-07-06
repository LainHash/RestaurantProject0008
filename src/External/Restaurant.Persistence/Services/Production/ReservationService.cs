using Restaurant.Application.Common.Enums;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Application.Mapping.Production;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using System.Net;

namespace Restaurant.Persistence.Services.Production
{
    internal class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<ReservationResponse>>>
            GetAllAsync(GetAllReservationsSpecification specification, CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationRepository.ToListAsync(specification, cancellationToken);

            var response = reservations.Select(r => new ReservationResponse(r));
            return Result<IEnumerable<ReservationResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<IEnumerable<ReservationResponse>>>
            GetAllByWeekAsync(GetAllReservationsByWeekSpecification specification, CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationRepository.ToListAsync(specification, cancellationToken);

            var response = reservations.Select(r => new ReservationResponse(r));
            return Result<IEnumerable<ReservationResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ReservationResponse>>
            GetByIdAsync(GetReservationByIdSpecification specification, CancellationToken cancellationToken = default)
        {
            var reservation = await _reservationRepository.FindAsync(specification, cancellationToken);
            if (reservation is null)
            {
                return Result<ReservationResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new ReservationResponse(reservation);
            return Result<ReservationResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ReservationResponse>> CreateForCustomerAsync(CreateReservationForCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var reservation = new Reservation(request.ToInfo());
            await _reservationRepository.AddAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new ReservationResponse(reservation);
            return Result<ReservationResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<ReservationResponse>> CreateForGuestAsync(CreateReservationForGuestRequest request, CancellationToken cancellationToken = default)
        {
            var reservation = new Reservation(request.ToInfo());
            await _reservationRepository.AddAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new ReservationResponse(reservation);
            return Result<ReservationResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }
    }
}
