using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.CompleteProfile
{
    internal class CompleteProfileCommandHandler : IRequestHandler<CompleteProfileCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService;
        public CompleteProfileCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<object>> Handle(CompleteProfileCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.CompleteProfileAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
