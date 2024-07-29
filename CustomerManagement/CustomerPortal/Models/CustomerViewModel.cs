using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerPortal.Models
{
    public class CustomerViewModel
    {
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
        public string Telephone { get; set; }
    }
}