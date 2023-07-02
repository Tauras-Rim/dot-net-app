using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services.Classes
{
    public class CustomerService : ICustomerService
    {

        private readonly CustomerContext _customerContext;

        public CustomerService(CustomerContext customerContext)
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

        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            if (_customerContext.Customers == null)
            {
                return new Customer();
            }
            var customer = await _customerContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return new Customer();
            }

            return customer;
        }

        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_customerContext.Customers == null)
            {
                return new List<Customer>();
            }
            return await _customerContext.Customers.ToListAsync(); ;
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
