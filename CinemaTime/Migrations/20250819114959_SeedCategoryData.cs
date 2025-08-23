using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTime.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorys (Name, Description) VALUES ('Action', 'this movie is the best in this category')");
            migrationBuilder.Sql("INSERT INTO Categorys (Name, Description) VALUES ('Comedy', 'funny movies')");
            migrationBuilder.Sql("INSERT INTO Categorys (Name, Description) VALUES ('Drama', 'emotional movies')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Categorys");

        }
    }
}
