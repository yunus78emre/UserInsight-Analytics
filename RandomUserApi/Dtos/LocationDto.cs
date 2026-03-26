using System.ComponentModel.DataAnnotations.Schema;

namespace RandomUserApi.Dtos
{
    public class LocationDto
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimezoneOffset { get; set; }
        public string TimezoneDescription { get; set; }
    }
}
