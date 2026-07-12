namespace Restaurant.Contract.DTOs.Personnel.Positions
{
    public class CreatePositionRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
