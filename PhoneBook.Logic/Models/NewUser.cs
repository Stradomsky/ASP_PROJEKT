namespace PhoneBookApp.Logic.Models
{
    public class NewUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
    }
}
