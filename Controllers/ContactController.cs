using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add([FromBody] ContactDto contact)
        {
            if (contact == null)
            {
                Console.WriteLine("❌ contact object is null");
                return BadRequest("Invalid request body");
            }

            if (string.IsNullOrWhiteSpace(contact.Name) ||
                string.IsNullOrWhiteSpace(contact.Email) ||
                string.IsNullOrWhiteSpace(contact.Phone))
            {
                Console.WriteLine("❌ One or more fields are missing");
                return BadRequest("Missing required fields");
            }

            Console.WriteLine($"✅ Received contact: {contact.Name}, {contact.Email}, {contact.Phone}");
            return Ok(new { message = "Contact added." });
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("✅ ContactController is alive");
        }
    }

    public class ContactDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}

