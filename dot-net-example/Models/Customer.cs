using System.ComponentModel.DataAnnotations;

namespace dot_net_example.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
    }
}
