using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUserApi.Services;

namespace RandomUserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null) return NotFound();

            return Ok(user);
        }
    }

}
