using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services.Classes
{
    public class UpdateService : IUpdateService
    {
        private readonly CustomerContext _customerContext;

        public UpdateService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<bool> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return false;
            }

            _customerContext.Entry(customer).State = EntityState.Modified;

            try
            {
                await _customerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool CustomerExists(long id)
        {
            return (_customerContext.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
