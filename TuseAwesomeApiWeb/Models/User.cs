using System.ComponentModel.DataAnnotations;

namespace TuseAwesomeApiWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Username { get; set; }
        [StringLength(50), Required]
        public string Password { get; set; }
        [StringLength(50), EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        public string Email { get; set; }
    }
}
