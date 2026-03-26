using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUserApi.Dtos;
using RandomUserApi.Services;

namespace RandomUserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var user = await _authService.ValidateLoginAsync(dto.username, dto.password);

            if (!user)
            {
                var failResponse = new LoginResponseDto
                {
                    Success = false,
                    Message = "Geçersiz kullanıcı adı veya şifre"

                };

                return Unauthorized(failResponse);
            }

            else
            {
                var successResponse = new LoginResponseDto
                {
                    Success = true,
                    Message = "Giriş başarılı"

                };

                return Ok(successResponse);
            }

        }
    }
}
