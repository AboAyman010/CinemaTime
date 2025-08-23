using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Users (FullName, Email, PhoneNumber, PasswordHash, Role)
                VALUES 
                ('Admin User', 'admin@cinema.com', '0100000000', 'hashed_password_here', 'Admin'),
                ('John Doe', 'john@example.com', '0111111111', 'hashed_password_here', 'Customer'),
                ('Jane Smith', 'jane@example.com', '0122222222', 'hashed_password_here', 'Customer'),
                ('Staff One', 'staff1@cinema.com', '0133333333', 'hashed_password_here', 'Staff')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Users");

        }
    }
}
