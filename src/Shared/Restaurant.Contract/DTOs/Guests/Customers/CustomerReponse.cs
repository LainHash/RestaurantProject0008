using Restaurant.Contract.DTOs.Identity.Profiles;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.Customers
{
    public class CustomerReponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string RoleName {  get; set; } = string.Empty;

        public ProfileResponse Profile { get; set; }

        public CustomerReponse(Customer customer)
        {
            Id = customer.Id;
            UserName = customer.User.UserName;
            Email = customer.User.Email;
            RoleName = customer.User.Role.Name;
            Profile = new ProfileResponse(customer.Profile);
        }
    }
}
