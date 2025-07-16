using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration config, ILogger<AuthController> logger)
        {
            _config = config;
            _logger = logger;
            _logger.LogInformation("🔥 AuthController constructor HIT");
        }

        // Health check endpoint
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("✅ AuthController is alive");
        }

        // Quick test endpoint
        [HttpGet("test")]
        public IActionResult Test()
        {
            _logger.LogInformation("🧪 /api/auth/test HIT!");
            return Ok("✅ AuthController is working!");
        }

        // Login endpoint
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("🔐 Login endpoint HIT");

            if (request == null || request.Username != "admin" || request.Password != "1234")
            {
                return Unauthorized("Invalid credentials");
            }

            var token = GenerateJwtToken("admin", "Admin");
            return Ok(new { token });
        }

        // JWT Token Generator
        private string GenerateJwtToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtKey = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];

            if (string.IsNullOrWhiteSpace(jwtKey) || string.IsNullOrWhiteSpace(issuer))
                throw new InvalidOperationException("JWT configuration is missing.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

