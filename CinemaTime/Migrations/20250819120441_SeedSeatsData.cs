using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedSeatsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seats (Hall A → 10x10 = 100 كرسي)
            for (int row = 1; row <= 10; row++)
            {
                for (int col = 1; col <= 10; col++)
                {
                    migrationBuilder.Sql($@"
                        INSERT INTO Seats (RowNumber, ColumnNumber, SeatType, IsAvailable, CinemaHallId) 
                        VALUES ({row}, {col}, 'Normal', 1, 1)");
                }
            }

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Seats");

        }
    }
}
