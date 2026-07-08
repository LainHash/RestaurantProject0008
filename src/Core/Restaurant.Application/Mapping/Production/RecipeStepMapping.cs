using Restaurant.Contract.DTOs.Production.RecipeSteps;
using Restaurant.Domain.Informations.Production.RecipeSteps;

namespace Restaurant.Application.Mapping.Production
{
    public static class RecipeStepMapping
    {
        public static CreateRecipeStepInformation ToInfo(this AddStepRequest request)
        {
            return new CreateRecipeStepInformation(
                RecipeId: request.RecipeId,
                Description: request.Description,
                StepNumber: request.StepNumber,
                DurationSeconds: request.DurationSeconds);
        }
    }
}
