namespace Restaurant.Contract.DTOs.Production.Discounts
{
    public class CreateDiscountRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}
