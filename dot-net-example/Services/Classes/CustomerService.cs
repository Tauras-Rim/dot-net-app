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

        public void DeleteCustomer(long id)
        {
            CheckIfCustomerExists(id);

            var customer = _customerContext.Customers.Find(id);

            _customerContext.Customers.Remove(customer);
            _customerContext.SaveChanges();
        }

        public ActionResult<Customer> GetCustomer(long id)
        {
            CheckIfCustomerExists(id);

            var customer = _customerContext.Customers.Find(id);

            return customer;
        }

        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _customerContext.Customers.ToList();
        }

        public  void PostCustomer(Customer customer)
        {
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
        }

        public void PutCustomer(long id, Customer customer)
        {
            CheckIfCustomerExists(id);

            _customerContext.Entry(customer).State = EntityState.Modified;

            _customerContext.SaveChanges();
        }

        private bool CheckIfCustomerExists(long id)
        {
            if ((_customerContext.Customers.Any(e => e.Id == id)))
            {
                return true;
            }
            throw new ArgumentException("Customer with id " + id + " not found");
        }
    }
}
