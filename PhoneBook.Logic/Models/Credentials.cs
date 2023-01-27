using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class Credentials
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login needs to be filled.")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password needs to be filled.")]
        public string Password { get; set; }
    }
}