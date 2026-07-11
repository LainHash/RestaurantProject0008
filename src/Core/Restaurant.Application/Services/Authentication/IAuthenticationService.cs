using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Result<object>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<Result<AuthenticationResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
        Task<Result<object>> VerifyEmailAsync(Guid userId, VerifyEmailRequest request, CancellationToken cancellationToken = default);
        Task<Result<object>> CompleteProfileAsync(Guid userId, CompleteProfileRequest request, CancellationToken cancellationToken = default);
    }
}
