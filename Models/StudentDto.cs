namespace StudentManagement.Models
{
    public class StudentDto
    {
        public int Id { get; set; } // Needed for Details/Edit/Delete links

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime EnrolledDate { get; set; }

        public string CourseTitle { get; set; } = string.Empty;
    }
}

