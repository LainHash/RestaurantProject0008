namespace Restaurant.Domain.Informations.Production.Reservations
{
    public sealed record CreateReservationForCustomerInformation(
        DateTime ReservationTime,
        int NumberOfGuests,
        TimeSpan DurationHours,
        string Status,
        string? Note,
        string AreaType);
}
