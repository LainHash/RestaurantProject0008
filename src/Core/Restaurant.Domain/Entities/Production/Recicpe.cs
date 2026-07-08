using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Informations.Production.Recipes;

namespace Restaurant.Domain.Entities.Production
{
    public partial class Recipe : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Inspiration { get; private set; }
        public string Note { get; private set; } = string.Empty;

        // Foreign Keys
        public Guid ProductId { get; private set; }


        // Navigation Properties
        public virtual Product Product { get; private set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; } = [];
        public virtual ICollection<RecipeStep> RecipeSteps { get; private set; } = [];
    }

    public partial class Recipe
    {
        public Recipe(string name, string? inspiration, string note, Guid productId)
        {
            Name = name;
            Inspiration = inspiration;
            Note = note;
            ProductId = productId;
        }

        public Recipe(CreateRecipeInformation information)
            : this (information.Name, information.Inspiration, information.Note, information.ProductId)
        {

        }
    }
}
