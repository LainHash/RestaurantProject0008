using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Domain.Informations.Production.Reservations
{
    public record CreateReservationInformation(
        DateTime ReservationTime,
        int NumberOfGuests,
        string Status,
        string? Note,
        Guid? CustomerId,
        TemporaryContact? TemporaryContact);
}
