using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class CreateStudentDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime EnrolledDate { get; set; }

        public int CourseId { get; set; }
    }
}

