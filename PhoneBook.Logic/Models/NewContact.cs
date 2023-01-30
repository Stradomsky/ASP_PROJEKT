using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class NewContact
    {
        public int PhoneBookId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name needs to be filled.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number needs to be filled.")]
        [StringLength(13, MinimumLength = 9, ErrorMessage = "Phone number must be between 9 and 13 character in length.")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description needs to be filled.")]
        public string Description { get; set; }
    }
}
