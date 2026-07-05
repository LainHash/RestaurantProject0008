using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Domain.Entities.Identity
{
    public class User : SoftDeletableEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public string? VerificationCode { get; set; }
        public DateTime? VerificationCodeExpiresAt { get; set; }
        public Guid RoleId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;

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
    }
}
