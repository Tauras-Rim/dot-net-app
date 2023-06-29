using dot_net_example.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class DeleteController
    {
        private readonly IDeleteService _deleteService;

        public DeleteController(IDeleteService deleteService)
        {
            _deleteService = deleteService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            return await _deleteService.DeleteCustomer(id);
        }
    }
}
