using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService;
        public RegisterCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<object>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.RegisterAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
