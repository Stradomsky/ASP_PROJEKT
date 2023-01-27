using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class PersonalDataEdition
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name needs to be filled.")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname needs to be filled.")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Age needs to be filled.")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address needs to be filled.")]
        public string EmailAddress { get; set; }
    }
}
