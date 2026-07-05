using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.VerifyEmail
{
    internal class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService;
        public VerifyEmailCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<object>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.VerifyEmailAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
