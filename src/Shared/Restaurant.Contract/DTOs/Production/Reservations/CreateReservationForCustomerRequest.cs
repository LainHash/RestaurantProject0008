namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class CreateReservationForCustomerRequest
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string? Note { get; set; }

        public Guid RestaurantTableId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
