namespace Restaurant.Domain.Informations.Identity.Users
{
    public sealed record CreateUserInformation(
            string UserName,
            string Email,
            string PasswordHash,
            Guid RoleId,
            string VerificationCode,
            DateTime VerificationCodeExpiresAt
        );
}
