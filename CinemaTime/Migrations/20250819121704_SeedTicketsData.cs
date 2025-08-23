using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedTicketsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ticket 1
            migrationBuilder.Sql(@"
        INSERT INTO Tickets (SessionId, SeatId, UserId, BookingTime, Price, Status)
        VALUES (9, 1,  1, GETDATE(), 150.00, 'Confirmed')
    ");

            // Ticket 2
            migrationBuilder.Sql(@"
        INSERT INTO Tickets (SessionId, SeatId, UserId, BookingTime, Price, Status)
        VALUES (11, 2, 2, GETDATE(), 150.00, 'Pending')
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Tickets");

        }
    }
}
