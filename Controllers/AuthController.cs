using Microsoft.AspNetCore.Mvc;
using MahasiswaApi.DTOs;
using MahasiswaApi.Services;
using Microsoft.AspNetCore.Identity;

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
        public async Task<IActionResult> Register([FromForm] string email, [FromForm] string password, [FromForm] IFormFile? photo)
        {
            string? photoPath = null;
            if (photo != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var savePath = Path.Combine("wwwroot", "uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
                photoPath = "/uploads/" + fileName;
            }

            var user = _authService.Register(email, password, photoPath);
            if (user == null)
                return Conflict(new { message = "Email already registered." });

            return Ok(new { message = "Registration successful." });
        }
    }
}