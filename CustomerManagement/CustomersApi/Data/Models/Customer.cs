using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CustomersApi.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
    }
}