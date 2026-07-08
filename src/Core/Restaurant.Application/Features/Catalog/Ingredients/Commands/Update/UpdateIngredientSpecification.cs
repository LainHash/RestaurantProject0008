using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Update
{
    public class UpdateIngredientSpecification : BaseSpecification<Ingredient>
    {
        public UpdateIngredientRequest Body { get; set; }
        public UpdateIngredientSpecification(UpdateIngredientCommand command)
        {
            Criteria = i => i.Id == command.Id;
            Body = command.Body;

            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);
        }
    }
}
