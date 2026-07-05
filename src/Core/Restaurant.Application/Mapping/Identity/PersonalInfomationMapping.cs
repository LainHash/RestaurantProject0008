using Restaurant.Contract.DTOs.Authentication;
using Restaurant.Domain.Informations.Identity.PersonalInformations;

namespace Restaurant.Application.Mapping.Identity
{
    public static class PersonalInfomationMapping
    {
        public static CreatePersonalInformationInformation ToInfo(this CompleteProfileRequest request)
        {
            return new CreatePersonalInformationInformation(
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
