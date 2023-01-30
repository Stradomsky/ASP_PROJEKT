using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class NewUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login needs to be filled.")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Login must be between 4 and 25 character in length.")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "New password needs to be filled.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 30 character in length.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Repeated new password needs to be filled.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 30 character in length.")]
        public string RepeatedPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address needs to be filled.")]
        public string EmailAddress { get; set; }
    }
}
