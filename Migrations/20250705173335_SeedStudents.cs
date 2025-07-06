using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Department", "Email", "EnrolledDate", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Science", "ali.khan@example.com", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali Khan" },
                    { 2, "Business Administration", "sara.ahmed@example.com", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara Ahmed" },
                    { 3, "Mathematics", "bilal.tariq@example.com", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilal Tariq" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
