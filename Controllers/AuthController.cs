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

        public AuthController(IConfiguration config)
        {
            Console.WriteLine("🔥 AuthController constructor HIT");
            _config = config;
        }

[HttpGet("ping")]
public IActionResult Ping()
{
    return Ok("AuthController is alive ✅");
}


        [HttpGet("test")]
        public IActionResult Test()
        {
            Console.WriteLine("🧪 /api/auth/test HIT!");
            return Ok("✅ AuthController is working!");
        }

     [HttpPost("login")]
public IActionResult Login([FromBody] LoginRequest request)
{
    Console.WriteLine("🔐 Login endpoint HIT");

    if (request.Username != "admin" || request.Password != "1234")
        return Unauthorized("Invalid credentials");

    var token = GenerateJwtToken("admin", "Admin");
    return Ok(new { token });
}


        private string GenerateJwtToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };
var jwtKey = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is missing from configuration.");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
