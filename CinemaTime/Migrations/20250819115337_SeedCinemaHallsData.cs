using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedCinemaHallsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CinemaHalls (Name, TotalSeats, Rows, Columns, Location) VALUES ('Hall A', 100, 10, 10, 'First Floor')");
            migrationBuilder.Sql("INSERT INTO CinemaHalls (Name, TotalSeats, Rows, Columns, Location) VALUES ('Hall B', 80, 8, 10, 'Second Floor')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE CinemaHalls");

        }
    }
}
