using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services
{
    public class PostService : ControllerBase, IPostService
    {
        private readonly CustomerContext _customerContext;

        public PostService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<bool> PostCustomer(Customer customer)
        {
            if (_customerContext.Customers == null)
            {
                return false;
            }
            _customerContext.Customers.Add(customer);
            await _customerContext.SaveChangesAsync();

            return true;
        }
    }
}
