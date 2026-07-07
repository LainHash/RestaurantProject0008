using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Domain.Informations.Catalog.Ingredients;

namespace Restaurant.Application.Mapping.Catalog
{
    public static class IngredientMapping
    {
        public static CreateIngredientInformation ToInfo(this CreateIngredientRequest request)
        {
            return new CreateIngredientInformation(
                        Name: request.Name,
                        Desctiption: request.Description,
                        UnitPrice: request.UnitPrice,
                        Unit: request.Unit,
                        StockQuantity: request.StockQuantity,
                        CategoryId: request.CategoryId);
        }
    }
}
