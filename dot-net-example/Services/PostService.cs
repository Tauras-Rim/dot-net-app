using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services
{
    public class PostService : ControllerBase, IPostService
    {
        private readonly CustomerContext _customerContext;

        public PostService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_customerContext.Customers == null)
            {
                return Problem("Entity set 'CustomerContext.Customers'  is null.");
            }
            _customerContext.Customers.Add(customer);
            await _customerContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCustomer), new { id = customer.Id }, customer);
        }
    }
}
