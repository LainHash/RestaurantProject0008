namespace Restaurant.Domain.Informations.Identity.Users
{
    public sealed partial record CreateUserInformation
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid RoleId;
        public string? VerificationCode { get; set; } = string.Empty;
        public DateTime? VerificationCodeExpiresAt { get; set; }

        public CreateUserInformation(
            string userName,
            string email,
            string passwordHash,
            Guid roleId)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }

        public CreateUserInformation(
            string userName,
            string email,
            string passwordHash,
            Guid roleId,
            string? verificationCode)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            RoleId = roleId;
            VerificationCode = verificationCode;
            VerificationCodeExpiresAt = DateTime.UtcNow.AddMinutes(15);
        }
    };
}
