using System.ComponentModel.DataAnnotations.Schema;

namespace RandomUserApi.Dtos
{
    public class AllUserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        
        public string Nationality { get; set; }
        
        public string PictureMediumUrl { get; set; }
        public string PictureLargeUrl { get; set; }
        public string PictureThumbnailUrl { get; set; }



        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        


    }
}
