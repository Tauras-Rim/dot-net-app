using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface IPostService
    {
        public Task<bool> PostCustomer(Customer customer);
    }
}
