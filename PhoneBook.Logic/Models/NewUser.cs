using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class NewUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login needs to be filled.")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "New password needs to be filled.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Repeated new password needs to be filled.")]
        public string RepeatedPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address needs to be filled.")]
        public string EmailAddress { get; set; }
    }
}
