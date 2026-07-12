using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Guests
{
    public partial class Customer : SoftDeletableEntity
    {
        public Guid UserId { get; private set; }
        public Guid? ProfileId { get; private set; }

        public virtual User User { get; private set; } = null!;
        public virtual Profile? Profile { get; private set; }
        public virtual ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();


        public virtual Cart? Cart { get; private set; } = null!;
        public virtual Wishlist? Wishlist { get; private set; } = null!;
    }

    public partial class Customer
    {
        public Customer() { }
        public Customer(Guid id, Guid userId, Guid? profileId = null)
        {
            Id = id;
            UserId = userId;
            ProfileId = profileId;
        }

        public Customer(Guid userId, Guid? profileId = null)
        {
            UserId = userId;
            ProfileId = profileId;
        }

        public void CompleteProfile(Guid piId)
        {
            ProfileId = piId;
        }
    }
}
