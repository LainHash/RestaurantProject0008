using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Informations.Production.RecipeSteps;

namespace Restaurant.Domain.Entities.Production
{
    public partial class RecipeStep : AuditableEntity
    {
        public string Description { get; private set; } = null!;
        public int StepNumber { get; private set; }
        public int DurationSeconds { get; private set; }

        public Guid RecipeId { get; private set; }

        public virtual Recipe Recipe { get; private set; } = null!;
    }

    public partial class RecipeStep
    {
        public RecipeStep(Guid recipeId, string description, int stepNumber, int durationSeconds)
        {
            RecipeId = recipeId;
            Description = description;
            StepNumber = stepNumber;
            DurationSeconds = durationSeconds;
        }

        public RecipeStep(Guid recipeId, CreateRecipeStepInformation information)
            : this(recipeId, information.Description, information.StepNumber, information.DurationSeconds)
        {
        }
    }
}
