using dot_net_example.Models;
using dot_net_example.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class PostController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return await _postService.PostCustomer(customer);
        }
    }
}
