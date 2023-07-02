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
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                return _customerService.GetCustomers();
            }
            catch (InvalidOperationException)
            {
                return NotFound("Customers list not found");
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
            catch (InvalidOperationException)
            {
                return NotFound("Customer list not found");
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

        // // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            try
            {
                _customerService.PostCustomer(customer);
                return Ok("Customer created");
            }
            catch (InvalidOperationException)
            {
                return NotFound("Customer list not found");
            }
            catch (NullReferenceException)
            {
                return Problem("No fields can be null");
            }
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
            catch (InvalidOperationException)
            {
                return NotFound("Customer list not found");
            }
            catch (ArgumentException)
            {
                return NotFound("Customer with id " + id + " not found");
            }
        }
    }
}
