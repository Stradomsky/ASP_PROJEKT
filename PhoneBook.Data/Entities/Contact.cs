namespace PhoneBookApp.Data.Entities
{
    public class Contact : EntityBase
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public virtual int PhoneBookId { get; set; }
    }
}
