using Restaurant.Application.Common.Enums;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Informations.Production.Reservations;

namespace Restaurant.Application.Mapping.Production
{
    public static class ReservationMapping
    {
        public static CreateReservationInformation ToInfo(this CreateReservationRequest request)
        {
            return new CreateReservationInformation(
                ReservationTime: request.ReservationTime,
                NumberOfGuests: request.NumberOfGuests,
                Status: nameof(ReservationStatus.Pending),
                Note: request.Note,
                CustomerId: request.CustomerId,
                TemporaryContact: request.TemporaryContact is not null 
                    ? new TemporaryContact(
                        request.TemporaryContact.GuestName,
                        request.TemporaryContact.GuestEmail,
                        request.TemporaryContact.GuestPhone) 
                    : null
                );
        }
    }
}
