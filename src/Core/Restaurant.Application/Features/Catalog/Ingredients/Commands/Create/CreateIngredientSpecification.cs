using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Create
{
    public class CreateIngredientSpecification : BaseSpecification<Ingredient>
    {
        public CreateIngredientRequest Body { get; set; }

        public CreateIngredientSpecification(CreateIngredientCommand command)
        {
            Body = command.Body;

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = i => i.Id == id;
        }
    }
}
