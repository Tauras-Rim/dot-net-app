using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface IGetService
    {
        public Task<ActionResult<IEnumerable<Customer>>> GetCustomers();

        public Task<ActionResult<Customer>> GetCustomer(long id);
    }
}
