using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Informations.Identity.Users;

namespace Restaurant.Domain.Entities.Identity
{
    public partial class User : SoftDeletableEntity
    {
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public decimal Balance { get; private set; }
        public bool IsActive { get; private set; }

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationCodeExpiresAt { get; private set; }
        public Guid RoleId { get; private set; }

        public virtual Customer Customer { get; private set; } = null!;
        public virtual Employee Employee { get; private set; } = null!;
        public virtual Role Role { get; private set; } = null!;

    }

    public partial class User
    {
        public User(Guid id, string userName, string email, string passwordHash, bool isActive, Guid roleId)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = isActive;
            RoleId = roleId;
        }

        public User(
            string userName,
            string email,
            string passwordHash,
            bool isActive,
            Guid roleId,
            string verificationCode,
            DateTime verificationCodeExpiresAt)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = isActive;
            RoleId = roleId;
            VerificationCode = verificationCode;
            VerificationCodeExpiresAt = verificationCodeExpiresAt;
        }

        public User(CreateUserInformation information)
        {
            UserName = information.UserName;
            Email = information.Email;
            PasswordHash = information.PasswordHash;
            RoleId = information.RoleId;
            VerificationCode = information.VerificationCode;
            if (information.VerificationCode is not null)
            {
                VerificationCodeExpiresAt = information.VerificationCodeExpiresAt;
            }
        }

        public void CompleteVerification()
        {
            IsActive = true;
            VerificationCode = null;
            VerificationCodeExpiresAt = null;
        }

        public void Active()
        {
            IsActive = true;
        }
    }
}
