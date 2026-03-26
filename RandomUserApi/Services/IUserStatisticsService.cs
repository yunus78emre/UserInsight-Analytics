using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data;
using RandomUserApi.Services;
using System.Threading.Tasks;
using System;


namespace RandomUserApi.Services
{
    public interface IStatisticsService
    {
        Task<int> GetTotalUserCountAsync();
        Task<double> GetAverageAgeAsync();
        Task<int> GetMaleCountAsync();
        Task<int> GetFemaleCountAsync();
        Task<List<CountryDistributionDto>> GetCountryDistributionAsync();
    }

    public class CountryDistributionDto
    {
        public string Country { get; set; }
        public int Count { get; set; }
    }

    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalUserCountAsync()
        {
            return await _context.users.CountAsync();
        }

        public async Task<double> GetAverageAgeAsync()
        {
            return await _context.users.AverageAsync(u => u.DobAge);
        }

        public async Task<int> GetMaleCountAsync()
        {
            return await _context.users.CountAsync(u => u.Gender.ToLower() == "male");
        }

        public async Task<int> GetFemaleCountAsync()
        {
            return await _context.users.CountAsync(u => u.Gender.ToLower() == "female");
        }

        public async Task<List<CountryDistributionDto>> GetCountryDistributionAsync()
        {
            return await _context.users
                .GroupBy(u => u.Nationality)
                .Select(g => new CountryDistributionDto
                {
                    Country = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();
        }
    }
}
