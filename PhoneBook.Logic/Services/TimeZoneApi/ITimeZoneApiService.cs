using PhoneBookApp.Logic.Models;

namespace PhoneBookApp.Logic.Services.TimeZoneApi
{
    public interface ITimeZoneApiService
    {
        TimeZoneApiResult GetTimeZone(string continent, string cityName);
    }
}
