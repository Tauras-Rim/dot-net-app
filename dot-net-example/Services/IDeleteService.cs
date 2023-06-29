using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services
{
    public interface IDeleteService
    {
        public Task<IActionResult> DeleteCustomer(long id);
    }
}
