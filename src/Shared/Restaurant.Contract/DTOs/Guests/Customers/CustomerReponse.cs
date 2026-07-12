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

        public DateOnly Dob { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string CitizenCardId { get; set; } = string.Empty;

        public CustomerReponse(Customer customer)
        {
            Id = customer.Id;
            UserName = customer.User.UserName;
            Email = customer.User.Email;
            FirstName = customer.Profile!.FirstName;
            LastName = customer.Profile.LastName;
            Dob = customer.Profile.Dob;
            Gender = customer.Profile.Gender ? "Male" : "Female";
            Address = customer.Profile.Address;
            City = customer.Profile.City;
            Country = customer.Profile.Country;
            Phone = customer.Profile.Phone;
            CitizenCardId = customer.Profile.CitizenCardId;
        }
    }
}
