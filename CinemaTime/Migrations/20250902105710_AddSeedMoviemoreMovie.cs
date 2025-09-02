using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedMoviemoreMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO Movies 
        (Title, Description, Duration, ReleaseDate, Language, Rating, PosterUrl, CategoryId, Price) 
        VALUES 
        ('Inception', 'Mind-bending thriller', 148, '2010-07-16', 'English', 8.8, 'poster1.jpg', 1, 120.00)
    ");

            // Movie 2
            migrationBuilder.Sql(@"
        INSERT INTO Movies 
        (Title, Description, Duration, ReleaseDate, Language, Rating, PosterUrl, CategoryId, Price) 
        VALUES 
        ('The Hangover', 'Comedy movie', 100, '2009-06-05', 'English', 7.7, 'poster2.jpg', 2, 90.00)
    ");

            // Movie 3
            migrationBuilder.Sql(@"
        INSERT INTO Movies 
        (Title, Description, Duration, ReleaseDate, Language, Rating, PosterUrl, CategoryId, Price) 
        VALUES 
        ('Interstellar', 'Epic sci-fi adventure', 169, '2014-11-07', 'English', 8.6, 'poster3.jpg', 1, 150.00)
    ");

            // Movie 4
            migrationBuilder.Sql(@"
        INSERT INTO Movies 
        (Title, Description, Duration, ReleaseDate, Language, Rating, PosterUrl, CategoryId, Price) 
        VALUES 
        ('Joker', 'Psychological thriller', 122, '2019-10-04', 'English', 8.5, 'poster4.jpg', 3, 110.00)
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Movies");

        }
    }
}
