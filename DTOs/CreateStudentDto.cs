using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTOs
{
    public class CreateStudentDto
    
    {
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public DateTime EnrolledDate { get; set; }

        public int CourseId { get; set; } // For dropdown selection
    }
}
