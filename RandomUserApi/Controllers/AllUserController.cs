using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandomUserApi.Dtos;
using RandomUserApi.Models;
using RandomUserApi.Services;
using System.Reflection;

namespace RandomUserApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AllUserController : ControllerBase
    {
        private readonly IAllUserService _allUserService;

        public AllUserController(IAllUserService allUserService)
        {
            _allUserService = allUserService;
        }

        [HttpGet("AllUser")]
        public async Task<ActionResult<PagedResult<AllUserDto>>> GetAllUsers(
        [FromQuery] string? gender,
        [FromQuery] string? nationality,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 18)
        {
            var pagedResult = await _allUserService.GetAllUsersAsync(gender, nationality, pageNumber, pageSize);
            return Ok(pagedResult);
        }

        [HttpGet("Nationalities")]
        public async Task<IActionResult> GetNationalities()
        {
            var nationalities = await _allUserService.GetAllNationalitiesAsync();
            return Ok(nationalities);
        }

    }

}
