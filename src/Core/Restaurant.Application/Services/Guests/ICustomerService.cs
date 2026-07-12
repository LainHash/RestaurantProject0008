using Restaurant.Application.Features.Guests.Customers.Queries.GetAll;
using Restaurant.Application.Features.Guests.Customers.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Customers;

namespace Restaurant.Application.Services.Guests
{
    public interface ICustomerService
    {
        Task<Result<IEnumerable<CustomerReponse>>>
            GetAllAsync(GetAllCustomersSpecification specification, CancellationToken cancellationToken);

        Task<Result<CustomerReponse>>
            GetByIdAsync(GetCustomerByIdSpecification specification, CancellationToken cancellationToken);
    }
}
