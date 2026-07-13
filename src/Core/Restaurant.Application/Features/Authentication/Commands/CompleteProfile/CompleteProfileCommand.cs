using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Authentication;
using Restaurant.Contract.DTOs.Identity.Profiles;

namespace Restaurant.Application.Features.Authentication.Commands.CompleteProfile
{
    public record CompleteProfileCommand(Guid UserId, CompleteProfileRequest Body) 
        : IRequest<Result<object>>;
}
