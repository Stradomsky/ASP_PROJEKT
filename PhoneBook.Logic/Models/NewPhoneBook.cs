using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class NewPhoneBook
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name needs to be filled.")]
        public string Name { get; set; }
    }
}
