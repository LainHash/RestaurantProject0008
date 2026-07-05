using Restaurant.Contract.DTOs.Authentication;
using Restaurant.Domain.Informations.Identity.Users;

namespace Restaurant.Application.Mapping.Identity
{
    public static class UserMapping
    {
        public static CreateUserInformation ToInfo(this RegisterRequest request, string passwordHash, Guid roleId, string verificationCode)
        {
            return new CreateUserInformation(
                request.UserName, 
                request.Email,
                passwordHash,
                roleId, 
                verificationCode,
                DateTime.UtcNow.AddMinutes(15));
        }
    }
}
