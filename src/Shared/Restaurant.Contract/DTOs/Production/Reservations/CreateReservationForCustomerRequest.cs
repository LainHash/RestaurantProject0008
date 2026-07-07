namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class CreateReservationForCustomerRequest
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public TimeSpan DurationHours { get; set; }
        public string? Note { get; set; }

        public Guid CustomerId { get; set; }

        public string AreaType { get; set; } = string.Empty;
    }
}
