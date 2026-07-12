using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Customers;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetAll
{
    public record GetAllCustomersQuery()
        : IRequest<Result<CustomerReponse>>
    {
    }
}
