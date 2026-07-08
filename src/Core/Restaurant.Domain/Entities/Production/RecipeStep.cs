using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Production
{
    public partial class RecipeStep : Entity
    {
        public string Description { get; private set; } = null!;
        public int StepNumber { get; private set; }
        public int DurationSeconds { get; private set; }

        public Guid RecipeId { get; private set; }

        public virtual Recipe Recipe { get; private set; } = null!;
    }
}
