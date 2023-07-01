using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services.Classes
{
    public class GetService : IGetService
    {
        private readonly CustomerContext _customerContext;

        public GetService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            if (_customerContext.Customers == null)
            {
                return new Customer();
            }
            var customer = await _customerContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return new Customer();
            }

            return customer;
        }

        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_customerContext.Customers == null)
            {
                return new List<Customer>();
            }
            return await _customerContext.Customers.ToListAsync(); ;
        }
    }
}
