using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services.Classes
{
    public class DeleteService : IDeleteService
    {
        private readonly CustomerContext _customerContext;

        public DeleteService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<bool> DeleteCustomer(long id)
        {
            if (_customerContext.Customers == null)
            {
                return false;
            }
            var customer = await _customerContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            _customerContext.Customers.Remove(customer);
            await _customerContext.SaveChangesAsync();

            return true;
        }
    }
}
