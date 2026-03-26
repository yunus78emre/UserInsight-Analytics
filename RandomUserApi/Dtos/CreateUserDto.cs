namespace RandomUserApi.Dtos
{
    public class CreateUserDto
    {
        
        public string Gender { get; set; }
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public DateTime DobDate { get; set; }
        public int DobAge { get; set; }
        public int RegisteredAge { get; set; }
        public string Nationality { get; set; }

        
        public string Username { get; set; }
        public string Password { get; set; }

        
        
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        

    }
}
