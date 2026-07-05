using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.CompleteProfile
{
    public record CompleteProfileCommand(CompleteProfileRequest Body) : IRequest<Result<object>>
    {
    }
}
