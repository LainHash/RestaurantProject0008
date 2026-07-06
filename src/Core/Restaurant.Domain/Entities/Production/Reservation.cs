using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Informations.Production.Reservations;
using System.Net.NetworkInformation;

namespace Restaurant.Domain.Entities.Production
{
    public partial class Reservation : SoftDeletableEntity
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }

        public Guid? CustomerId { get; set; }
        public Guid? TemporaryContactId { get; set; }
        public Guid RestaurantTableId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual TemporaryContact? TemporaryContact { get; set; }
        public virtual RestaurantTable RestaurantTable { get; set; } = null!;

    }

    public partial class Reservation
    {
        public Reservation(Guid id, DateTime reservationTime, int numberOfGuests, string status, Guid restaurantTableId, string? note = null, Guid? customerId = null, Guid? temporaryContactId = null)
        {
            Id = id;
            ReservationTime = reservationTime;
            NumberOfGuests = numberOfGuests;
            Status = status;
            Note = note;
            CustomerId = customerId;
            TemporaryContactId = temporaryContactId;
            RestaurantTableId = restaurantTableId;
        }

        public Reservation(DateTime reservationTime, int numberOfGuests, string status, Guid restaurantTableId, string? note)
        {
            ReservationTime = reservationTime;
            NumberOfGuests = numberOfGuests;
            Status = status;
            Note = note;
            RestaurantTableId = restaurantTableId;
        }

        public Reservation(DateTime reservationTime, int numberOfGuests, string status, Guid restaurantTableId, string? note, Guid customerId)
            : this(reservationTime, numberOfGuests, status, restaurantTableId, note)
        {
            CustomerId = customerId;
        }

        public Reservation(DateTime reservationTime, int numberOfGuests, string status, Guid restaurantTableId, string? note, TemporaryContact temporaryContact)
            : this(reservationTime, numberOfGuests, status, restaurantTableId, note)
        {
            TemporaryContact = temporaryContact;
        }

        public Reservation(CreateReservationForCustomerInformation information)
        {
            ReservationTime = information.ReservationTime;
            NumberOfGuests = information.NumberOfGuests;
            Status = information.Status;
            Note = information.Note;
            RestaurantTableId = information.RestaurantTableId;
            CustomerId = information.CustomerId;
        }

        public Reservation(CreateReservationForGuestInformation information)
        {
            ReservationTime = information.ReservationTime;
            NumberOfGuests = information.NumberOfGuests;
            Status = information.Status;
            Note = information.Note;
            RestaurantTableId = information.RestaurantTableId;
            TemporaryContact = new TemporaryContact(information.GuestName, information.GuestEmail, information.GuestPhone);
        }
    }
}
