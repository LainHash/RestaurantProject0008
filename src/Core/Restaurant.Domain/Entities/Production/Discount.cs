using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Production
{
    public class Discount : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Type { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public DateTime? ExpiredAt { get; private set; }
        public decimal Value { get; private set; }
    }
}
