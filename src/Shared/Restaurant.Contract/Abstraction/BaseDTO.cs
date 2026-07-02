namespace Restaurant.Contract.Abstraction
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }
    }

    public abstract class AuditableDTO : BaseDTO
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public abstract class SoftDeletableDTO : AuditableDTO
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
