using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Contract.DTOs.Personnel.Positions
{
    public class PositionResponse
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public PositionResponse(Position position)
        {
            Name = position.Name;
            Description = position.Description;
        }
    }
}
