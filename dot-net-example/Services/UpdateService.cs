using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services
{
    public class UpdateService : ControllerBase, IUpdateService
    {
        private readonly CustomerContext _customerContext;

        public UpdateService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerContext.Entry(customer).State = EntityState.Modified;

            try
            {
                await _customerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return (_customerContext.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
