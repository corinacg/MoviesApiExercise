using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT COLLATE NOCASE", nullable: true),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    RunningTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserRatings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 1, 27, 2003, 178, "Dogville" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 2, 23, 2017, 100, "A Dog's Purpose" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 3, 19, 2002, 109, "The Emperor's Club" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 4, 19, 2016, 128, "La La Land" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 5, 31, 2017, 123, "The Shape of Water" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 6, 31, 2001, 104, "The Others" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 7, 23, 2004, 101, "The Machinist" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 8, 15, 2017, 141, "Wonder Woman" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 9, 15, 2005, 157, "Harry Potter and the Goblet of Fire" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "RunningTime", "Title" },
                values: new object[] { 10, 19, 2001, 135, "A Beautiful Mind" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "joe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 2, "alex" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 3, "henry" });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 3, 3, 5 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 3, 1, 4 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 10, 2 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 9, 1 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 4, 4 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 8, 3 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 7, 2 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 5, 1 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 3, 3 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 1, 8, 3 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 1, 7, 5 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 1, 5, 1 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 1, 3, 3 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 3, 5, 3 });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "UserId", "MovieId", "Rating" },
                values: new object[] { 3, 7, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MovieId",
                table: "UserRatings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
