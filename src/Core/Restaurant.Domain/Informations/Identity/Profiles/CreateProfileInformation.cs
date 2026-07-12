namespace Restaurant.Domain.Informations.Identity.Profiles
{
    public sealed record CreateProfileInformation(
            string FirstName,
            string LastName,
            DateOnly Dob,
            bool Gender,
            string Address,
            string City,
            string Country,
            string Phone,
            string CitizenCardId
        );
}
