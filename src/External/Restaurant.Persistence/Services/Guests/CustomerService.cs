using Restaurant.Application.Features.Guests.Customers.Queries.GetAll;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Customers;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;

namespace Restaurant.Persistence.Services.Guests
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<IEnumerable<CustomerReponse>>> GetAllAsync(GetAllCustomersSpecification specification, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.ToListAsync(specification, cancellationToken);

            var response = customers.Select(x => new CustomerReponse(x));
            return Result<IEnumerable<CustomerReponse>>
                .Succeed(response, Success<Customer>.Retrieved);
        }
    }
}
