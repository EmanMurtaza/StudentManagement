using System.ComponentModel.DataAnnotations;
using StudentManagement.Models;

namespace StudentManagement.Models
{
    public class Students
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime EnrolledDate { get; set; }

        public int CourseId { get; set; }
        [Required, StringLength(100)]             // Foreign Key


        public Course Course { get; set; } 
       

    }
}