using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class ChangePassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Old password needs to be filled.")]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "New password needs to be filled.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "New password must be between 6 and 30 character in length.")]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Repeated new password needs to be filled.")]
        public string RepeatedNewPassword { get; set; }
    }
}
