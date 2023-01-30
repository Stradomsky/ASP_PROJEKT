using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Data.Entities
{
    public class User : EntityBase
    {
        public string Login { get; set; }
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