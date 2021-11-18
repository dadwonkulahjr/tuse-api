using System.ComponentModel.DataAnnotations;

namespace TuseAwesomeApiWeb.Dtos
{
    public class UpdateUserDto
    {
        [StringLength(50), Required]
        public string Username { get; set; }
        [StringLength(50), Required]
        public string Password { get; set; }
        [StringLength(50), EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }
}
