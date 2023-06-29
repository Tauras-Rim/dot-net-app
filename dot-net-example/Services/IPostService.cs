using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services
{
    public interface IPostService
    {
        public Task<ActionResult<Customer>> PostCustomer(Customer customer);
    }
}
