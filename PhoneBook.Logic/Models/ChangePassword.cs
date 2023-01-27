using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class ChangePassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Old password needs to be filled.")]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "New password needs to be filled.")]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Repeated new password needs to be filled.")]
        public string RepeatedNewPassword { get; set; }
    }
}
