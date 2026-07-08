namespace Restaurant.Contract.DTOs.Production.RecipeSteps
{
    public class AddStepRequest
    {
        public string Description { get; set; } = null!;
        public int StepNumber { get; set; }
        public int DurationSeconds { get; set; }

        public Guid RecipeId { get; set; }
    }
}
