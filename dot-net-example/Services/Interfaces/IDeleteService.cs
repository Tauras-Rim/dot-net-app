using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface IDeleteService
    {
        public Task<bool> DeleteCustomer(long id);
    }
}
