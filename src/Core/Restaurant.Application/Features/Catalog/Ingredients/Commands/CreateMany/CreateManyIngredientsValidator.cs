using FluentValidation;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.Create;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany
{
    internal class CreateManyIngredientsValidator : AbstractValidator<CreateManyIngredientsCommand>
    {
        public CreateManyIngredientsValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty();

            RuleForEach(x => x.Body)
                .SetValidator(new CreateIngredientValidator());
        }
    }

    
}
