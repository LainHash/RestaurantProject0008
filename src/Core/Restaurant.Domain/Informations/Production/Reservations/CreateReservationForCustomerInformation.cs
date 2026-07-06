namespace Restaurant.Domain.Informations.Production.Reservations
{
    public sealed record CreateReservationForCustomerInformation(
        DateTime ReservationTime,
        int NumberOfGuests,
        string Status,
        string? Note,
        Guid RestaurantTableId,
        Guid CustomerId);
}
