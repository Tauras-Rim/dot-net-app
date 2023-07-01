using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_net_example.Models;
using dot_net_example.Services.Interfaces;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;
        private readonly IDeleteService _deleteService;
        private readonly IGetService _getService;
        private readonly IPostService _postService;
        private readonly IUpdateService _updateService;

        public CustomersController(CustomerContext context, IDeleteService deleteService, IGetService getService, IPostService postService, IUpdateService updateService)
        {
            _context = context;
            _deleteService = deleteService;
            _getService = getService;
            _postService = postService;
            _updateService = updateService;
        }

        // //GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _getService.GetCustomers();
        }

        // //GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
             return await _getService.GetCustomer(id);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            return await _updateService.PutCustomer(id, customer) ? Ok("Customer with id " + id + " updated") : NotFound();
        }

        // // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return await _postService.PostCustomer(customer) ? Ok("Customer created") : Problem("Invalid customer");
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            return await _deleteService.DeleteCustomer(id) ? Ok("Customer with id " + id + " deleted") : NotFound();
        }

        //private bool CustomerExists(long id)
        //{
        //    return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
