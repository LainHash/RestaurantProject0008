using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Domain.Entities.Identity
{
    public class PersonalInformation : SoftDeletableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateOnly Dob { get; set; }
        public bool Gender { get; set; }

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string CitizenCardId { get; set; } = string.Empty;

        public PersonalInformation(Guid id, string firstName, string lastName, DateOnly dob, bool gender, string address, string city, string country, string phone, string citizenCardId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Dob = dob;
            Gender = gender;
            Address = address;
            City = city;
            Country = country;
            Phone = phone;
            CitizenCardId = citizenCardId;
        }

        public virtual Customer Customer { get; set; } = null!;
    }
}
