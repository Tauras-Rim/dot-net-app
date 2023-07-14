using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface ICustomerService
    {
        public void DeleteCustomer(long id);

        public ActionResult<IEnumerable<Customer>> GetCustomers();

        public ActionResult<Customer> GetCustomer(long id);

        public void PostCustomer(Customer customer);

        public void PutCustomer(long id, Customer customer);

        public bool CheckIfCustomerExists(long id);
    }
}
