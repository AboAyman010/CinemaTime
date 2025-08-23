using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedMovieActorsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1, 1); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1, 2); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1002, 3); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1003, 4); 
     INSERT INTO MovieActor (MovieId, ActorId) VALUES (1004, 5); 
    INSERT INTO MovieActor (MovieId, ActorId) VALUES (1005, 6); 
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE MovieActor");

        }
    }
}
