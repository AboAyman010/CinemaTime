using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedMovieImageData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO MovieImages (MovieId, ImageUrl)
        VALUES 
        (1, 'images/inception_scene1.jpg'),
        (1, 'images/inception_scene2.jpg'),
        (1, 'images/inception_poster.jpg')
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE MovieImages");

        }
    }
}
