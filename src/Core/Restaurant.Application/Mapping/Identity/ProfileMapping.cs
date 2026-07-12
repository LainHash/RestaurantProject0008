using Restaurant.Contract.DTOs.Authentication;
using Restaurant.Domain.Informations.Identity.Profiles;

namespace Restaurant.Application.Mapping.Identity
{
    public static class ProfileMapping
    {
        public static CreateProfileInformation ToInfo(this CompleteProfileRequest request)
        {
            return new CreateProfileInformation(
                    request.FirstName,
                    request.LastName,
                    request.DOB,
                    request.Gender,
                    request.Address,
                    request.City,
                    request.Country,
                    request.Phone,
                    request.CitizenCardId
                );
        }
    }
}
