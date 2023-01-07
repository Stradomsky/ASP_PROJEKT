namespace PhoneBookApp.Data.Entities
{
    public class PersonalData : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
    }
}
