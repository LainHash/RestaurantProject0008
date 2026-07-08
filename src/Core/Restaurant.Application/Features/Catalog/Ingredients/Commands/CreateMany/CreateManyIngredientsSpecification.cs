using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany
{
    public class CreateManyIngredientsSpecification : BaseSpecification<Ingredient>
    {
        public IEnumerable<CreateIngredientRequest> Bodies { get; set; }

        public CreateManyIngredientsSpecification(CreateManyIngredientsCommand command)
        {
            Bodies = command.Body;

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }

        public void ApplyCriteria(ICollection<Guid> ids)
        {
            Criteria = i => ids.Contains(i.Id);
        }
    }
}
