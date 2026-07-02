namespace Restaurant.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        protected Entity()
        {
            Id = Guid.CreateVersion7();
        }
    }

    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime UpdatedAt { get; protected set; } = DateTime.Now;
    }

    public abstract class SoftDeletableEntity : AuditableEntity
    {
        public bool IsDeleted { get; protected set; } = false;
        public DateTime? DeletedAt { get; protected set; } = null;
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }
    }
}
