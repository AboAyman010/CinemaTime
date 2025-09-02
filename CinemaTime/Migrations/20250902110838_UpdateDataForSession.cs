using CinemaTime.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataForSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO Sessions (MovieId, HallId, StartTime, EndTime, Price)
        VALUES
        (3, 1, '2025-08-20 18:00:00', '2025-08-20 20:30:00', 120.00),
        (3, 2, '2025-08-20 21:00:00', '2025-08-20 23:30:00', 100.00),
        (4, 2, '2025-08-21 17:00:00', '2025-08-21 20:00:00', 150.00),
        (4, 1, '2025-08-22 20:00:00', '2025-08-22 23:00:00', 140.00),
     
       (5, 1, '2025-08-20 18:00:00', '2025-08-20 20:30:00', 120.00),
        (5, 2, '2025-08-20 21:00:00', '2025-08-20 23:30:00', 100.00),
        (6, 2, '2025-08-21 17:00:00', '2025-08-21 20:00:00', 150.00),
        (6, 1, '2025-08-22 20:00:00', '2025-08-22 23:00:00', 140.00);
    ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Sessions");

        }
    }
}
