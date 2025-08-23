using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class NewDataToSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO Sessions (MovieId, HallId, StartTime, EndTime, Price)
        VALUES
     (1002, 1, '2025-08-20 21:00:00', '2025-08-20 23:30:00', 120.00),
(1003, 2, '2025-08-20 22:00:00', '2025-08-21 00:30:00', 100.00),
(1004, 2, '2025-08-21 23:00:00', '2025-08-22 01:00:00', 150.00),
(1005, 1, '2025-08-22 00:00:00', '2025-08-22 02:00:00', 140.00);

    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Sessions");

        }
    }
}
