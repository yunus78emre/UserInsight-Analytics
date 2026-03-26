using Microsoft.AspNetCore.Mvc;
using RandomUserApi.Dtos;
using RandomUserApi.Models;
using RandomUserApi.Services;

namespace RandomUserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly ICreateService _createService;

        public CreateController(ICreateService createService)
        {
            _createService = createService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserDto dto)
        {
            try
            {
                var user = await _createService.CreateUserAsync(dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, details = ex.InnerException?.ToString() });
            }
        }
    }

}
