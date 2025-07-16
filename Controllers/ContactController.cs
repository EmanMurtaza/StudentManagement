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
            if (string.IsNullOrWhiteSpace(contact.Name) ||
                string.IsNullOrWhiteSpace(contact.Email) ||
                string.IsNullOrWhiteSpace(contact.Phone))
            {
                return BadRequest("Missing fields");
            }

            Console.WriteLine($"📝 Received contact: {contact.Name}, {contact.Email}, {contact.Phone}");
            return Ok(new { message = "Contact added." });
        }
    }

    public class ContactDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
