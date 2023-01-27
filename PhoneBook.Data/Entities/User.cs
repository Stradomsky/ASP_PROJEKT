using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Data.Entities
{
    public class User : EntityBase
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Login musi mieć od 5 do 20 znaków")]
        [RegularExpression(@"^[a-zA-Z0-9!@#\$%\^\&\*\(\)_\+\-=\[\]{};':"",\.\/<>\?\\|]+$", ErrorMessage = "Login może zawierać tylko litery, liczby i znaki specjalne")]
        public string Login { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Hasło musi mieć od 5 do 20 znaków")]
        [RegularExpression(@"^[a-zA-Z0-9!@#\$%\^\&\*\(\)_\+\-=\[\]{};':"",\.\/<>\?\\|]+$", ErrorMessage = "Hasło może zawierać tylko litery, liczby i znaki specjalne")]
        public string Password { get; set; }
        public bool IsPremium { get; set; }
        public virtual int PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }
        public virtual ICollection<PhoneBook> PhoneBooks { get; set; }

        public User()
        {
            PhoneBooks = new HashSet<PhoneBook>();
        }
    }
}