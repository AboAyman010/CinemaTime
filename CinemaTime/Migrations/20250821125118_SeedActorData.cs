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
        INSERT INTO Actors (Name, Photo) 
        VALUES (N'Leonardo DiCaprio', 'https://upload.wikimedia.org/wikipedia/commons/7/7e/Leonardo_DiCaprio_66ème_Festival_de_Venise_%28Mostra%29.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actors (Name, Photo) 
        VALUES (N'Christian Bale', 'https://upload.wikimedia.org/wikipedia/commons/8/8a/Christian_Bale_2019.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actors (Name, Photo) 
        VALUES (N'Bradley Cooper', 'https://upload.wikimedia.org/wikipedia/commons/8/82/Bradley_Cooper_2018.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actors (Name, Photo) 
        VALUES (N'Will Smith', 'https://upload.wikimedia.org/wikipedia/commons/f/fd/Will_Smith_2011%2C_2.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actors (Name, Photo) 
        VALUES (N'Scarlett Johansson', 'https://upload.wikimedia.org/wikipedia/commons/6/6e/Scarlett_Johansson_by_Gage_Skidmore_2.jpg');
    ");

            migrationBuilder.Sql(@"
        INSERT INTO Actors (Name, Photo) 
        VALUES (N'Robert Downey Jr.', 'https://upload.wikimedia.org/wikipedia/commons/5/50/Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg');
    ");
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Actors");

        }
    }
}
