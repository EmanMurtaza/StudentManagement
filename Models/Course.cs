namespace StudentManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
       public string Title { get; set; } = string.Empty;
public ICollection<Students> Students { get; set; } = new List<Students>();

    }
}
