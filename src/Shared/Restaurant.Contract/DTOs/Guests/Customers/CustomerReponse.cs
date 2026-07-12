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
            FirstName = customer.PersonalInformation!.FirstName;
            LastName = customer.PersonalInformation.LastName;
            Dob = customer.PersonalInformation.Dob;
            Gender = customer.PersonalInformation.Gender ? "Male" : "Female";
            Address = customer.PersonalInformation.Address;
            City = customer.PersonalInformation.City;
            Country = customer.PersonalInformation.Country;
            Phone = customer.PersonalInformation.Phone;
            CitizenCardId = customer.PersonalInformation.CitizenCardId;
        }
    }
}
