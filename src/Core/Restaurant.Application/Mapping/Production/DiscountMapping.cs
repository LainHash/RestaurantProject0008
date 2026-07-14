using Restaurant.Contract.DTOs.Production.Discounts;
using Restaurant.Domain.Informations.Production.Discounts;

namespace Restaurant.Application.Mapping.Production
{
    public static class DiscountMapping
    {
        public static CreateDiscountInformation ToInfo(this CreateDiscountRequest request)
        {
            return new CreateDiscountInformation(
                    Name: request.Name,
                    Code: request.Code,
                    Type: request.Type,
                    Description: request.Description,
                    ExpiredAt: request.ExpiredAt,
                    Value: request.Value,
                    Quantity: request.Quantity);
        }
    }
}
