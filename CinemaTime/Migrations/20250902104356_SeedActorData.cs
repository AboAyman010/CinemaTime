using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedActorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO Actor (Name, Photo) 
        VALUES (N'Leonardo DiCaprio', '~/');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actor (Name, Photo) 
        VALUES (N'Christian Bale', 'images/bait.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actor (Name, Photo) 
        VALUES (N'Bradley Cooper', 'images/girl.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actor (Name, Photo) 
        VALUES (N'Will Smith', 'images/gon.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actor (Name, Photo) 
        VALUES (N'Scarlett Johansson', 'images/lenardo.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actor (Name, Photo) 
        VALUES (N'Robert Downey Jr.', 'images/nam.jpg');
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Actors");

        }
    }
}
