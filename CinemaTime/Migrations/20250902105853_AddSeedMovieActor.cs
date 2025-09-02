using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedMovieActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1, 1); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1, 2); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (3, 3); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (4, 4); 
     INSERT INTO MovieActor (MovieId, ActorId) VALUES (5, 5); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (6, 6); 
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE MovieActor");

        }
    }
}
