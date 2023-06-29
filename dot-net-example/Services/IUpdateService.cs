using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services
{
    public interface IUpdateService
    {
        public Task<IActionResult> PutCustomer(long id, Customer customer);
    }
}
