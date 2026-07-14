using Microsoft.AspNetCore.Http;
using Restaurant.Application.Services.Misc;
using System.Security.Claims;

namespace Restaurant.Persistence.Services.Misc
{
    /// <summary>
    /// Lấy thông tin user hiện tại từ HTTP context (JWT Claims).
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc/>
        public string? UserId =>
            _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        /// <inheritdoc/>
        public string? UserName =>
            _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value
            ?? _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;

        /// <inheritdoc/>
        public string? IpAddress =>
            _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    }
}
