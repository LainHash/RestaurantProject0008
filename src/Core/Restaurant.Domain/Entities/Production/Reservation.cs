using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Informations.Production.Reservations;

namespace Restaurant.Domain.Entities.Production
{
    public partial class Reservation : SoftDeletableEntity
    {
        public DateTime ReservationTime { get; private set; }
        public int NumberOfGuests { get; private set; }
        public TimeSpan DurationHours { get; private set; }
        public string Status { get; private set; } = string.Empty;
        public string? Note { get; private set; }

        public Guid? CustomerId { get; private set; }
        public Guid? TemporaryContactId { get; private set; }
        public Guid RestaurantTableId { get; private set; }

        public virtual Customer? Customer { get; private set; }
        public virtual TemporaryContact? TemporaryContact { get; private set; }
        public virtual RestaurantTable RestaurantTable { get; private set; } = null!;

    }

    public partial class Reservation
    {
        public Reservation(Guid id, DateTime reservationTime, int numberOfGuests, TimeSpan durationHours, string status, Guid restaurantTableId, string? note = null, Guid? customerId = null, Guid? temporaryContactId = null)
        {
            Id = id;
            ReservationTime = reservationTime;
            NumberOfGuests = numberOfGuests;
            DurationHours = durationHours;
            Status = status;
            Note = note;
            CustomerId = customerId;
            TemporaryContactId = temporaryContactId;
            RestaurantTableId = restaurantTableId;
        }

        public Reservation(DateTime reservationTime, int numberOfGuests, TimeSpan durationHours, string status, Guid restaurantTableId, string? note)
        {
            ReservationTime = reservationTime;
            NumberOfGuests = numberOfGuests;
            DurationHours = durationHours;
            Status = status;
            Note = note;
            RestaurantTableId = restaurantTableId;
        }

        public Reservation(DateTime reservationTime, int numberOfGuests, TimeSpan durationHours, string status, Guid restaurantTableId, string? note, Guid customerId)
            : this(reservationTime, numberOfGuests, durationHours, status, restaurantTableId, note)
        {
            CustomerId = customerId;
        }

        public Reservation(DateTime reservationTime, int numberOfGuests, TimeSpan durationHours, string status, Guid restaurantTableId, string? note, TemporaryContact temporaryContact)
            : this(reservationTime, numberOfGuests, durationHours, status, restaurantTableId, note)
        {
            TemporaryContact = temporaryContact;
        }

        public Reservation(CreateReservationForCustomerInformation information)
        {
            ReservationTime = information.ReservationTime;
            NumberOfGuests = information.NumberOfGuests;
            DurationHours = information.DurationHours;
            Status = information.Status;
            Note = information.Note;
        }

        public Reservation(CreateReservationForGuestInformation information)
        {
            ReservationTime = information.ReservationTime;
            NumberOfGuests = information.NumberOfGuests;
            DurationHours = information.DurationHours;
            Status = information.Status;
            Note = information.Note;
            TemporaryContact = new TemporaryContact(information.GuestName, information.GuestEmail, information.GuestPhone);
        }

        public void AddTable(Guid tableId)
        {
            RestaurantTableId = tableId;
        }

        public void AddCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
