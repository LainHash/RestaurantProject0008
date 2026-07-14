using Restaurant.Domain.Entities.Production;

namespace Restaurant.Contract.DTOs.Production.Discounts
{
    public class DiscountResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public decimal Value { get; set; }

        public DiscountResponse(Discount discount)
        {
            Name = discount.Name;
            Code = discount.Code;
            Type = discount.Type;
            Description = discount.Description;
            ExpiredAt = discount.ExpiredAt;
            Value = discount.Value;
        }
    }
}
