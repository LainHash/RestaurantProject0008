using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.VerifyEmail
{
    public record VerifyEmailCommand(Guid UserId, VerifyEmailRequest Body) : IRequest<Result<object>>;
}
