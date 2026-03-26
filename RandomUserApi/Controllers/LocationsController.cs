using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUserApi.Services;

namespace RandomUserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetLocation(int userId)
        {
            var location = await _locationService.GetLocationByUserIdAsync(userId);
            if (location ==null ) return NotFound();

            return Ok(location);
        }
    }

}
