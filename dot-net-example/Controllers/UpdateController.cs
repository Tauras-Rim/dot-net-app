using dot_net_example.Models;
using dot_net_example.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class UpdateController
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            return await _updateService.PutCustomer(id, customer);
        }
    }
}
