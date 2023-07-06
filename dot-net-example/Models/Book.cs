using System.ComponentModel.DataAnnotations.Schema;

namespace dot_net_example.Models
{
    public class Book
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public long? PageCount { get; set; }

        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
