using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Data.Entities
{
    public class PhoneBook : EntityBase
    {
        public string Name { get; set; }
        public int MaxSize { get; set; }
        public virtual int UserId { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

        public PhoneBook()
        {
            Contacts = new HashSet<Contact>();
        }
    }
}
