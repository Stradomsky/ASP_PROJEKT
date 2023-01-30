using PhoneBookApp.Data.Entities;

namespace PhoneBookApp.Logic.Models
{
    public  class PersonalDataPack
    {
        public User User { get; set; }

        public TimeZoneApiResult TimeZoneApiResult { get; set; }
    }
}
