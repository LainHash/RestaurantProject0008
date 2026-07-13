using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Contract.DTOs.Personnel.Employees
{
    public class CreateEmployeeRequest
    {
        public RegisterRequest Register { get; set; } = null!;

        public DateOnly HiredDate { get; set; }
        public decimal BaseSalary { get; set; }
        public string Status { get; set; } = string.Empty;

        public Guid RoleId { get; set; }
        public Guid PositionId { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
