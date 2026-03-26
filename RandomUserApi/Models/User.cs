using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace RandomUserApi.Models
{



    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("title_name")]
        public string Title { get; set; }

        [Column("first_name")]
        public string First { get; set; }

        [Column("last_name")]
        public string Last { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("cell")]
        public string Cell { get; set; }

        [Column("dob_date")]
        public DateTime DobDate { get; set; }

        [Column("dob_age")]
        public int DobAge { get; set; }

        [Column("registered_date")]
        public DateTime RegisteredDate { get; set; }

        [Column("registered_age")]
        public int RegisteredAge { get; set; }

        [Column("id_name")]
        public string? IdName { get; set; }

        [Column("id_value")]
        public string? IdValue { get; set; }

        [Column("nationality")]
        public string Nationality { get; set; }

        [Column("picture_large_url")]
        public string? PictureLargeUrl { get; set; }

        [Column("picture_medium_url")]
        public string? PictureMediumUrl { get; set; }

        [Column("picture_thumbnail_url")]
        public string? PictureThumbnailUrl { get; set; }

        [Column("location_id")]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        [Column("login_id")]
        public int LoginId { get; set; }

        public Login Login { get; set; }
    }




}

