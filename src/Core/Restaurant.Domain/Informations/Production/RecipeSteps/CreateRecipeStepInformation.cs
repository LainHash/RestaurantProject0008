namespace Restaurant.Domain.Informations.Production.RecipeSteps
{
    public record CreateRecipeStepInformation(
        string Description,
        int StepNumber,
        int DurationSeconds);
}
