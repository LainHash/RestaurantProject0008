using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Informations.Production.Discounts;

namespace Restaurant.Domain.Entities.Production
{
    public partial class Discount : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Type { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public DateTime? ExpiredAt { get; private set; }
        public decimal Value { get; private set; }
        public int Quantity { get; private set; }
    }

    public partial class Discount
    {
        public Discount(CreateDiscountInformation information)
        {
            Name = information.Name;
            Code = information.Code;
            Type = information.Type;
            Description = information.Description;
            ExpiredAt = information.ExpiredAt;
            Value = information.Value;
            Quantity = information.Quantity;
        }
    }
}
