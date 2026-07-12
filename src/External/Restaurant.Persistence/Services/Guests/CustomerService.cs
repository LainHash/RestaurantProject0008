using Restaurant.Application.Features.Guests.Customers.Queries.GetAll;
using Restaurant.Application.Features.Guests.Customers.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Customers;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using System.Net;

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

        public async Task<Result<CustomerReponse>> GetByIdAsync(GetCustomerByIdSpecification specification, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindAsync(specification, cancellationToken);
            if (customer is null)
            {
                return Result<CustomerReponse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new CustomerReponse(customer);
            return Result<CustomerReponse>
                .Succeed(response, Success<Customer>.Retrieved);
        }
    }
}
