using Microsoft.AspNetCore.Mvc;
using dot_net_example.Models;
using dot_net_example.Services.Interfaces;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // //GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
             return _customerService.GetCustomers();
        }

        // // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Customer> PostCustomer([FromBody] Customer customer)
        {
            _customerService.PostCustomer(customer);
            return Ok("Customer created");
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return Ok("Customer with id " + id + " deleted");
            }
            catch (ArgumentException)
            {
                return NotFound("Customer with id " + id + " not found");
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCustomer(long id, Customer customer)
        {
            try
            {
                _customerService.PutCustomer(id, customer);
                return Ok("Customer with id " + id + " updated");
            }
            catch (ArgumentException)
            {
                return NotFound("Customer with id " + id + " not found");
            }
        }

        // //GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(long id)
        {
            try
            {
                return _customerService.GetCustomer(id);
            }
            catch (ArgumentException)
            {
                return NotFound("Customer with id " + id + " not found");
            }
        }
    }
}
