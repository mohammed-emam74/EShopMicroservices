using System.ComponentModel.DataAnnotations;

namespace Identity.API.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Confirm Password name is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = default!;
    }
}
