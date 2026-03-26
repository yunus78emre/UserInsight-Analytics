namespace RandomUserApi.Dtos
{
    public class UserStatisticsDto
    {
        public int TotalUsers { get; set; }
        public double AverageAge { get; set; }
        public int FemaleCount { get; set; }
        public int MaleCount { get; set; }
        public string MostRecentUser { get; set; }
    }
}
