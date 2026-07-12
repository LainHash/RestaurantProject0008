using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Customers;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetById
{
    public record GetCustomerByIdQuery(Guid Id)
        : IRequest<Result<CustomerReponse>>
    {
    }
}
