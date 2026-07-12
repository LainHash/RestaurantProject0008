using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Contract.DTOs.Personnel.Employees
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string PositionName {  get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateOnly Dob { get; set; }
        public string Gender { get; set; } = null!;

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string CitizenCardId { get; set; } = string.Empty;

        public EmployeeResponse(Employee employee)
        {
            Id = employee.Id;
            UserName = employee.User.UserName;
            Email = employee.User.Email;
            PositionName = employee.Position.Name;
            FirstName = employee.Profile!.FirstName;
            LastName = employee.Profile.LastName;
            Dob = employee.Profile.Dob;
            Gender = employee.Profile.Gender ? "Male" : "Female";
            Address = employee.Profile.Address;
            City = employee.Profile.City;
            Country = employee.Profile.Country;
            Phone = employee.Profile.Phone;
            CitizenCardId = employee.Profile.CitizenCardId;
        }
    }
}
