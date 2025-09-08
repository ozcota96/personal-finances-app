using System.ComponentModel.DataAnnotations;

namespace core_api.Models.Request
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 15 characters.")]
        public string Password { get; set; } = string.Empty;
    }
}
