using PhoneBookApp.Logic.Models;
using RestSharp;
using System;

namespace PhoneBookApp.Logic.Services.TimeZoneApi
{
    public class TimeZoneApiService : ITimeZoneApiService
    {
        private readonly string _developmentApiKey = "VZ0VY0GKFGJ1";
        private readonly string _apiUrl = @"http://api.timezonedb.com/v2.1";
        private readonly string _endpointName = @"get-time-zone";

        // America  Chicago
        public TimeZoneApiResult GetTimeZone(string continent, string cityName)
        {
            try
            {
                RestClient restClient = new RestClient(_apiUrl);

                string uri = $"{_endpointName}?key={_developmentApiKey}&format=xml&by=zone&zone={continent}/{cityName}";

                RestRequest restRequest = new RestRequest(uri);

                TimeZoneApiResult timeZoneApiResult = restClient.Get<TimeZoneApiResult>(restRequest);

                return timeZoneApiResult;
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred on api side: {e.Message}", e);
            }
        }
    }
}
