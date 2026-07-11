using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.DeleteExpired
{
    public record DeleteExpiredCartCommand()
        : IRequest<Result<object>>
    {
    }
}
