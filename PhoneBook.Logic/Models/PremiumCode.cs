using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Logic.Models
{
    public class PremiumCode
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code needs to be filled.")]
        public string ActivationCode { get; set; }
    }
}
