using Restaurant.Contract.DTOs.Production.Recipes;
using Restaurant.Domain.Informations.Production.Recipes;

namespace Restaurant.Application.Mapping.Production
{
    public static class RecipeMapping
    {
        public static CreateRecipeInformation ToInfo(this CreateRecipeRequest request)
        {
            return new CreateRecipeInformation(
                    Name: request.Name,
                    Inspiration: request.Inspiration,
                    Note: request.Note,
                    ProductId: request.ProductId
                );
        }
    }
}
