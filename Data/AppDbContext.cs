using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Students>().HasData(
                new Students
                {
                    Id = 1,
                    Name = "Ali Khan",
                    Email = "ali.khan@example.com",
                    Department = "Computer Science",
                    EnrolledDate = new DateTime(2023, 9, 1)
                },
                new Students
                {
                    Id = 2,
                    Name = "Sara Ahmed",
                    Email = "sara.ahmed@example.com",
                    Department = "Business Administration",
                    EnrolledDate = new DateTime(2022, 8, 15)
                },
                new Students
                {
                    Id = 3,
                    Name = "Bilal Tariq",
                    Email = "bilal.tariq@example.com",
                    Department = "Mathematics",
                    EnrolledDate = new DateTime(2024, 1, 5)
                }
            );
        }
    }
}
