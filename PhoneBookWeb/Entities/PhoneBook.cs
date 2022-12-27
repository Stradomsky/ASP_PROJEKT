using System.Collections.Generic;

namespace PhoneBookWeb.Entities
{
    public class PhoneBook : EntityBase
    {
        public virtual ICollection<Contact> Contacts { get; set; }
        public int MaxSize { get; set; }
    }
}
