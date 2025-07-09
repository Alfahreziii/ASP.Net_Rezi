using Microsoft.AspNetCore.Mvc;
using MahasiswaApi.DTOs;
using MahasiswaApi.Services;

namespace MahasiswaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _authService.GetUserByEmail(dto.Email);
            if (user == null)
                return NotFound(new { message = "Email not registered." });

            if (!_authService.CheckPassword(user, dto.Password))
                return Unauthorized(new { message = "Incorrect password." });

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var user = _authService.Register(dto.Email, dto.Password);
            if (user == null)
                return Conflict(new { message = "Email already registered." });

            return Ok(new { message = "Registration successful." });
        }
    }
}