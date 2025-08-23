using CinemaTime.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class NewDataSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    DELETE FROM Sessions;

    INSERT INTO Sessions (MovieId, HallId, StartTime, EndTime, Price)
    VALUES
    (1, 1, '2025-08-20 18:00:00', '2025-08-20 20:30:00', 120.00),
    (2, 1, '2025-08-22 20:00:00', '2025-08-22 23:00:00', 140.00);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Sessions");

        }
    }
}
