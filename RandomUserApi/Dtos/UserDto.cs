namespace RandomUserApi.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string DateOfBirth { get; set; }
        public int DobAge { get; set; }
        public string Nationality { get; set; }
        public string RegisteredDate { get; set; }
        public int RegisteredAge { get; set; }
        public string? IdName { get; set; }
        public string? IdValue { get; set; }
        public string PictureMediumUrl { get; set; }
        public string PictureLargeUrl { get; set; }
        public string PictureThumbnailUrl { get; set; }
    }
}
