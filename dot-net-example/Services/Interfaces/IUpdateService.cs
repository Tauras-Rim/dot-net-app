using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface IUpdateService
    {
        public Task<bool> PutCustomer(long id, Customer customer);
    }
}
