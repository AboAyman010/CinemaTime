using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoviesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies ( Title, Description, Duration, ReleaseDate, Language, Rating, PosterUrl, CategoryId) VALUES ( 'Inception', 'Mind-bending thriller', 148, '2010-07-16', 'English', 8.8, 'poster1.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Movies ( Title, Description, Duration, ReleaseDate, Language, Rating, PosterUrl, CategoryId) VALUES ( 'The Hangover', 'Comedy movie', 100, '2009-06-05', 'English', 7.7, 'poster2.jpg', 2)");
       
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Movies");

        }
    }
}
