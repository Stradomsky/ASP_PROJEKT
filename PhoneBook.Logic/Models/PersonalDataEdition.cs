using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class PersonalDataEdition
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name needs to be filled.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 15 character in length.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname needs to be filled.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 30 character in length.")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Age needs to be filled.")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address needs to be filled.")]
        public string EmailAddress { get; set; }
    }
}
