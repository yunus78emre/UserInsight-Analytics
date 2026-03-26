using System.ComponentModel.DataAnnotations.Schema;

namespace RandomUserApi.Models
{


    public class Location
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("street_number")]
        public int? StreetNumber { get; set; }

        [Column("street_name")]
        public string StreetName { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("postcode")]
        public string? Postcode { get; set; }

        [Column("latitude")]
        public string? Latitude { get; set; }

        [Column("longitude")]
        public string? Longitude { get; set; }

        [Column("timezone_offset")]
        public string? TimezoneOffset { get; set; }

        [Column("timezone_description")]
        public string? TimezoneDescription { get; set; }
    }


}
