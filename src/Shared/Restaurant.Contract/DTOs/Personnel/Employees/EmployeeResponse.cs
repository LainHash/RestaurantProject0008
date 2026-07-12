using Restaurant.Contract.DTOs.Identity.Profiles;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Contract.DTOs.Personnel.Employees
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string RoleName {  get; set; } = string.Empty;
        public string PositionName {  get; set; } = string.Empty;

        public ProfileResponse Profile { get; set; }

        public EmployeeResponse(Employee employee)
        {
            Id = employee.Id;
            UserName = employee.User.UserName;
            Email = employee.User.Email;
            RoleName = employee.User.Role.Name;
            PositionName = employee.Position.Name;
            Profile = new ProfileResponse(employee.Profile);
        }
    }
}
