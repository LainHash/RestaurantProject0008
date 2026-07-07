using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll
{
    public class GetAllIngredientsSpecification : BaseSpecification<Ingredient>
    {
        public GetAllIngredientsSpecification(GetAllIngredientsQuery query)
        {
            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }
    }
}
