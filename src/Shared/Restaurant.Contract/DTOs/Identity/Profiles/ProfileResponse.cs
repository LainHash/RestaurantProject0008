using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Contract.DTOs.Identity.Profiles
{
    public class ProfileResponse
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateOnly Dob { get; set; }
        public string Gender { get; set; } = null!;

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string CitizenCardId { get; set; } = string.Empty;

        public ProfileResponse(Profile? profile)
        {
            FirstName = profile!.FirstName;
            LastName = profile.LastName;
            Dob = profile.Dob;
            Gender = profile.Gender ? "Male" : "Female";
            Address = profile.Address;
            City = profile.City;
            Country = profile.Country;
            Phone = profile.Phone;
            CitizenCardId = profile.CitizenCardId;
        }
    }
}
