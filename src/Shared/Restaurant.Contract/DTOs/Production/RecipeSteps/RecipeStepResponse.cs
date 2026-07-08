using Restaurant.Domain.Entities.Production;

namespace Restaurant.Contract.DTOs.Production.RecipeSteps
{
    public class RecipeStepResponse
    {
        public string Description { get; private set; } = null!;
        public int StepNumber { get; private set; }
        public int DurationSeconds { get; private set; }

        public RecipeStepResponse(RecipeStep recipeStep)
        {
            Description = recipeStep.Description;
            StepNumber = recipeStep.StepNumber;
            DurationSeconds = recipeStep.DurationSeconds;
        }
    }
}
