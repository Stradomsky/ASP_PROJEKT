using System;
using System.Xml.Serialization;

namespace PhoneBookApp.Logic.Models
{
    [XmlRoot(ElementName = "result")]
    public class TimeZoneApiResult
    {

        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "message")]
        public object Message { get; set; }

        [XmlElement(ElementName = "countryCode")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "countryName")]
        public string CountryName { get; set; }

        [XmlElement(ElementName = "regionName")]
        public object RegionName { get; set; }

        [XmlElement(ElementName = "cityName")]
        public object CityName { get; set; }

        [XmlElement(ElementName = "zoneName")]
        public string ZoneName { get; set; }

        [XmlElement(ElementName = "abbreviation")]
        public string Abbreviation { get; set; }

        [XmlElement(ElementName = "gmtOffset")]
        public int GmtOffset { get; set; }

        [XmlElement(ElementName = "dst")]
        public int Dst { get; set; }

        [XmlElement(ElementName = "zoneStart")]
        public int ZoneStart { get; set; }

        [XmlElement(ElementName = "zoneEnd")]
        public int ZoneEnd { get; set; }

        [XmlElement(ElementName = "nextAbbreviation")]
        public string NextAbbreviation { get; set; }

        [XmlElement(ElementName = "timestamp")]
        public int Timestamp { get; set; }

        [XmlElement("formatted")]
        public string Formatted { get; set; }

        [XmlIgnore]
        public DateTime? FormattedX
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Formatted))
                {
                    return DateTime.Parse(Formatted);
                }

                return null;
            }
        }
    }
}
