namespace Restaurant.Domain.Informations.Production.Reservations
{
    public sealed record CreateReservationForGuestInformation(
        DateTime ReservationTime,
        int NumberOfGuests,
        TimeSpan DurationHours,
        string Status,
        string? Note,
        string GuestName,
        string GuestEmail,
        string GuestPhone,
        string AreaType);
}
