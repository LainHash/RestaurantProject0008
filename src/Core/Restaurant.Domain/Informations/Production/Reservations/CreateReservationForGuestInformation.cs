namespace Restaurant.Domain.Informations.Production.Reservations
{
    public sealed record CreateReservationForGuestInformation(
        DateTime ReservationTime,
        int NumberOfGuests,
        string Status,
        string? Note,
        Guid RestaurantTableId,
        string GuestName,
        string GuestEmail,
        string GuestPhone);
}
