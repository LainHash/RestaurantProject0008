using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.Application.Features.Authentication.Commands.Register
{
    public record RegisterCommand(RegisterRequest Body) : IRequest<Result<object>>
    {
    }
}
