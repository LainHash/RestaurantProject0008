using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Guests
{
    public class Customer : SoftDeletableEntity
    {
        public Guid UserId { get; set; }
        public Guid? PIId { get; set; }

        public Customer(Guid id, Guid userId, Guid? piId = null)
        {
            Id = id;
            UserId = userId;
            PIId = piId;
        }

        public virtual User User { get; set; } = null!;
        public virtual PersonalInformation? PersonalInformation { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
