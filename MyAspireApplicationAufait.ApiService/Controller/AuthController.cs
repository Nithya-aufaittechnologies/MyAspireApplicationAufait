using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspireApplicationAufait.ApiService.Application.Dtos;
using MyAspireApplicationAufait.ApiService.Application.Interfaces;
using MyAspireApplicationAufait.ApiService.Application.Services;

namespace MyAspireApplicationAufait.ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(ApplicationDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _context.ApplicationUser
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (user == null)
                return Unauthorized("Invalid username or password");

            // Check password (here using a simple method, you should hash and compare properly in production)
            if (user.PasswordHash != model.Password)
                return Unauthorized("Invalid username or password");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
