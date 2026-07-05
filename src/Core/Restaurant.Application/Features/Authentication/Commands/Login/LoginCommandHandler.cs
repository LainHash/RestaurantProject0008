using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Authentication;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthenticationResponse>>
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<AuthenticationResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.LoginAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
