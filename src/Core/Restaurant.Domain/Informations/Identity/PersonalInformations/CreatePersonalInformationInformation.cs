namespace Restaurant.Domain.Informations.Identity.PersonalInformations
{
    public sealed record CreatePersonalInformationInformation(
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
