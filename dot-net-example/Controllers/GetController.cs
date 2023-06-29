using dot_net_example.Models;
using dot_net_example.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class GetController
    {
        private readonly IGetService _getService;

        public GetController(IGetService getService)
        {
            _getService = getService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _getService.GetCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            return await _getService.GetCustomer(id);
        }
    }
}
