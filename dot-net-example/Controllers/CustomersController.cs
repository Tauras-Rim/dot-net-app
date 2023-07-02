using Microsoft.AspNetCore.Mvc;
using dot_net_example.Models;
using dot_net_example.Services.Interfaces;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // //GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _customerService.GetCustomers();
        }

        // //GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
             return await _customerService.GetCustomer(id);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            return await _customerService.PutCustomer(id, customer) ? Ok("Customer with id " + id + " updated") : NotFound();
        }

        // // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return await _customerService.PostCustomer(customer) ? Ok("Customer created") : Problem("Invalid customer");
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            return await _customerService.DeleteCustomer(id) ? Ok("Customer with id " + id + " deleted") : NotFound();
        }
    }
}
