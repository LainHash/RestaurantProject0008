using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Informations.Identity.PersonalInformations;

namespace Restaurant.Domain.Entities.Identity
{
    public partial class PersonalInformation : SoftDeletableEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public DateOnly Dob { get; private set; }
        public bool Gender { get; private set; }

        public string Address { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;

        public string Phone { get; private set; } = string.Empty;
        public string CitizenCardId { get; private set; } = string.Empty;


        public virtual Customer Customer { get; private set; } = null!;
    }

    public partial class PersonalInformation
    {

        public PersonalInformation(
            Guid id,
            string firstName,
            string lastName,
            DateOnly dob,
            bool gender,
            string address,
            string city,
            string country,
            string phone,
            string citizenCardId)
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

        public PersonalInformation(
            string firstName,
            string lastName,
            DateOnly dob,
            bool gender,
            string address,
            string city,
            string country,
            string phone,
            string citizenCardId)
        {
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

        public PersonalInformation(CreatePersonalInformationInformation information)
        {
            FirstName = information.FirstName;
            LastName = information.LastName;
            Dob = information.Dob;
            Gender = information.Gender;
            Address = information.Address;
            City = information.City;
            Country = information.Country;
            Phone = information.Phone;
            CitizenCardId = information.CitizenCardId;
        }
    }
}
