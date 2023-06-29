using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services
{
    public class DeleteService : ControllerBase, IDeleteService
    {
        private readonly CustomerContext _customerContext;

        public DeleteService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<IActionResult> DeleteCustomer(long id)
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

            _customerContext.Customers.Remove(customer);
            await _customerContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
