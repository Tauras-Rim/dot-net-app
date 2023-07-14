using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace dot_net_example.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
