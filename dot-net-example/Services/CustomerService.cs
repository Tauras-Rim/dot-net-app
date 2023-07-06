using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services.Classes
{
    public class CustomerService : ICustomerService
    {
        private readonly LibraryContext _libraryContext;

        public CustomerService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public void DeleteCustomer(long id)
        {
            CheckIfCustomerExists(id);

            var customer = _libraryContext.Customers.Find(id);

            _libraryContext.Customers.Remove(customer);
            _libraryContext.SaveChanges();
        }

        public ActionResult<Customer> GetCustomer(long id)
        {
            CheckIfCustomerExists(id);

            return _libraryContext.Customers.Find(id);
        }

        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _libraryContext.Customers.ToList();
        }

        public  void PostCustomer(Customer customer)
        {
            _libraryContext.Customers.Add(customer);
            _libraryContext.SaveChanges();
        }

        public void PutCustomer(long id, Customer customer)
        {
            CheckIfCustomerExists(id);

            _libraryContext.Entry(customer).State = EntityState.Modified;

            _libraryContext.SaveChanges();
        }

        private bool CheckIfCustomerExists(long id)
        {
            if (_libraryContext.Customers.Any(e => e.Id == id))
            {
                return true;
            }
            throw new ArgumentException("Customer with id " + id + " not found");
        }
    }
}
