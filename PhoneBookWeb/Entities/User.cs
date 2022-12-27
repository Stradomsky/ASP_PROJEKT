namespace PhoneBookWeb.Entities
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsPremium { get; set; }
        public virtual PhoneBook PhoneBook { get; set; }
        public virtual PersonalData PersonalData { get; set; }
    }
}
