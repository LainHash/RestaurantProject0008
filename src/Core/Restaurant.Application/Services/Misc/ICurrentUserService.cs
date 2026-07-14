namespace Restaurant.Application.Services.Misc
{
    /// <summary>
    /// Cung cấp thông tin về người dùng đang thực hiện request hiện tại.
    /// Được implement trong Persistence layer từ IHttpContextAccessor.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>ClaimTypes.NameIdentifier từ JWT token. Null nếu chưa xác thực.</summary>
        string? UserId { get; }

        /// <summary>ClaimTypes.Name hoặc Email từ JWT token. Null nếu chưa xác thực.</summary>
        string? UserName { get; }

        /// <summary>IP address của client request hiện tại.</summary>
        string? IpAddress { get; }
    }
}
