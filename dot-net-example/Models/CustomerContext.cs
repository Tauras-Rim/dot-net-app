using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace dot_net_example.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null;
    }
}
