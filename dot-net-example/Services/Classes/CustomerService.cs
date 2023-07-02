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
            CheckIfCustomerListExists();

            var customer = _customerContext.Customers.Find(id);

            CheckIfCustomerExists(customer, id);

            _customerContext.Customers.Remove(customer);
            _customerContext.SaveChanges();
        }

        public ActionResult<Customer> GetCustomer(long id)
        {
            CheckIfCustomerListExists();

            var customer = _customerContext.Customers.Find(id);

            CheckIfCustomerExists(customer, id);

            return customer;
        }

        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            CheckIfCustomerListExists();

            return _customerContext.Customers.ToList(); ;
        }

        public  void PostCustomer(Customer customer)
        {
            CheckIfCustomerListExists();

            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
        }

        public void PutCustomer(long id, Customer customer)
        {
            CheckIfCustomerListExists();

            if (id != customer.Id)
            {
                throw new ArgumentException("Incorrect customer id");
            }

            _customerContext.Entry(customer).State = EntityState.Modified;

            _customerContext.SaveChanges();
        }

        private void CheckIfCustomerListExists()
        {
            if (_customerContext.Customers == null)
            {
                throw new InvalidOperationException("Customer list does't exist");
            }
        }

        private void CheckIfCustomerExists(Customer customer, long id)
        {
            if (customer == null)
            {
                throw new ArgumentException("Customer with id" + id + " doesn't exist");
            }
        }

        private bool CustomerExists(long id)
        {
            return (_customerContext.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
