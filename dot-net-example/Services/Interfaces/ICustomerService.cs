using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<bool> DeleteCustomer(long id);

        public Task<ActionResult<IEnumerable<Customer>>> GetCustomers();

        public Task<ActionResult<Customer>> GetCustomer(long id);

        public Task<bool> PostCustomer(Customer customer);

        public Task<bool> PutCustomer(long id, Customer customer);
    }
}
