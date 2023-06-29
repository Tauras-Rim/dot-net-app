using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services
{
    public class GetService : ControllerBase, IGetService
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
                return NotFound();
            }
            var customer = await _customerContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_customerContext.Customers == null)
            {
                return NotFound();
            }
            return await _customerContext.Customers.ToListAsync(); ;
        }
    }
}
