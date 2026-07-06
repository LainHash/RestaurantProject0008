using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Application.Mapping.Production;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
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
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
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

        public async Task<Result<ReservationResponse>> CreateAsync(CreateReservationRequest request, CancellationToken cancellationToken = default)
        {
            var reservation = new Reservation(request.ToInfo());
            await _reservationRepository.AddAsync(reservation);

            var response = new ReservationResponse(reservation);
            return Result<ReservationResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public Task<Result<ReservationResponse>> UpdateAsync(Guid id, UpdateReservationRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
