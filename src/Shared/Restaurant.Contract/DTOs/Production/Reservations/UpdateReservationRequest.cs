namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class UpdateReservationRequest
    {
        public Guid Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }

        public Guid? CustomerId { get; set; }
        public UpdateReservationRequest? TemporaryContact { get; set; }
    }
}
