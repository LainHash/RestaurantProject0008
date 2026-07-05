using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(LoginRequest Body) : IRequest<Result<AuthenticationResponse>>
    {
    }
}
