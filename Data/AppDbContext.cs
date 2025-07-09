using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Seed Courses
    modelBuilder.Entity<Course>().HasData(
        new Course { Id = 1, Title = "Web Development" },
        new Course { Id = 2, Title = "Database Systems" }
    );

    // Seed Students with linked courses
    modelBuilder.Entity<Students>().HasData(
        new Students
        {
            Id = 1,
            Name = "Ali Khan",
            Email = "ali.khan@example.com",
            Department = "Computer Science",
            EnrolledDate = new DateTime(2023, 9, 1),
            CourseId = 1
        },
        new Students
        {
            Id = 2,
            Name = "Sara Ahmed",
            Email = "sara.ahmed@example.com",
            Department = "Business Administration",
            EnrolledDate = new DateTime(2022, 8, 15),
            CourseId = 2
        }
    );
}

    }
}
