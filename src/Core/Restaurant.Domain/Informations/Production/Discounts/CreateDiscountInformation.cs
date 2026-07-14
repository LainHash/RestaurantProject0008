namespace Restaurant.Domain.Informations.Production.Discounts
{
    public sealed record CreateDiscountInformation(
        string Name,
        string Code,
        string Type,
        string? Description,
        DateTime? ExpiredAt,
        decimal Value,
        int Quantity);
}
