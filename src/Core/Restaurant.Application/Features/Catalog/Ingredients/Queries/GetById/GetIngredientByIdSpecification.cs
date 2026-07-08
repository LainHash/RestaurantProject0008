using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById
{
    public class GetIngredientByIdSpecification : BaseSpecification<Ingredient>
    {
        public GetIngredientByIdSpecification(GetIngredientByIdQuery query)
        {
            Criteria = i => i.Id == query.Id;

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }

        public GetIngredientByIdSpecification(Guid id)
        {
            Criteria = i => i.Id == id;

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }
    }
}
