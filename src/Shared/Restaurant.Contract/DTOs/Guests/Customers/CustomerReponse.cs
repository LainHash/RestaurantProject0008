using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Contract.DTOs.Guests.Customers
{
    public class CustomerReponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public CustomerReponse(Customer customer)
        {
            Id = customer.Id;
            UserName = customer.User.UserName;
            Email = customer.User.Email;
            FirstName = customer.PersonalInformation!.FirstName;
            LastName = customer.PersonalInformation.LastName;
            Phone = customer.PersonalInformation.Phone;
        }
    }
}
