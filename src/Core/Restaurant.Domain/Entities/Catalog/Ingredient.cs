using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Informations.Catalog.Ingredients;

namespace Restaurant.Domain.Entities.Catalog
{
    public partial class Ingredient : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public Guid CategoryId { get; private set; }

        public virtual Category Category { get; private set; } = null!;
        public virtual IngredientStock IngredientStock { get; private set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; } = [];
    }

    public partial class Ingredient
    {
        public Ingredient() { }

        public Ingredient(CreateIngredientInformation information)
        {
            Name = information.Name;
            Description = information.Desctiption;
            CategoryId = information.CategoryId;
            IngredientStock = new IngredientStock(information.UnitPrice, information.Unit, information.StockQuantity);
        }

        public void Update(string name, string? description, Guid categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
