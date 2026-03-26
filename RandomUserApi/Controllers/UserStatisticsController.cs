    using Microsoft.AspNetCore.Mvc;
    using RandomUserApi.Services;

    namespace RandomUserApi.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class StatisticsController : ControllerBase
        {
            private readonly IStatisticsService _statisticsService;

            public StatisticsController(IStatisticsService statisticsService)
            {
                _statisticsService = statisticsService;
            }

            [HttpGet("statistics")]
            public async Task<IActionResult> GetSummary()
            {
                var totalUsers = await _statisticsService.GetTotalUserCountAsync();
                var averageAge = await _statisticsService.GetAverageAgeAsync();
                var maleCount = await _statisticsService.GetMaleCountAsync();
                var femaleCount = await _statisticsService.GetFemaleCountAsync();
                var countryDistribution = await _statisticsService.GetCountryDistributionAsync();

                return Ok(new
                {
                    TotalUsers = totalUsers,
                    AverageAge = Math.Round(averageAge, 1),
                    MaleCount = maleCount,
                    FemaleCount = femaleCount,
                    CountryDistribution = countryDistribution
                });
            }
        }
    }
