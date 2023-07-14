using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dot_net_example.Models
{
    public class Book
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public long PageCount { get; set; }

        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }
    }
}
