using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById
{
    public class GetIngredientsByIdsSpecification : BaseSpecification<Ingredient>
    {
        public GetIngredientsByIdsSpecification(ICollection<Guid> ids)
        {
            Criteria = i => ids.Contains(i.Id);

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }
    }
}
